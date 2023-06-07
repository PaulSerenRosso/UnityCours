using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerCommands : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float moveTime = 0.5f;
    [SerializeField] private KeyCode upKey = KeyCode.UpArrow;
    [SerializeField] private KeyCode leftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode rightKey = KeyCode.RightArrow;
    [SerializeField] private KeyCode downKey = KeyCode.DownArrow;
    private CommandInvoker commandInvoker;

    private void Awake()
    {
        commandInvoker = new CommandInvoker();
    }

    private void Update()
    {
        if (Input.GetKeyDown(upKey))
        {
            Move(Vector3.forward);
        }

        if (Input.GetKeyDown(leftKey))
        {
            Move(Vector3.left);
        }

        if (Input.GetKeyDown(downKey))
        {
            Move(Vector3.back);
        }

        if (Input.GetKeyDown(rightKey))
        {
            Move(Vector3.right);
        }

        Vector3? clickPosition = GetClickPosition();
        if (clickPosition.HasValue)
        {
            MoveToCommand moveToCommand =
                new MoveToCommand(this, clickPosition.Value, player.transform.position);
            commandInvoker.Execute(moveToCommand);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            commandInvoker.Undo();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            commandInvoker.Redo();
        }
    }

    private void Move(Vector3 direction)
    {
        ICommand moveCommand = new MoveCommand(player, direction);
        commandInvoker.Execute(moveCommand);
    }

    public void MoveTo(Vector3 endPos)
    {
        StartCoroutine(MoveToInSeconds(player, endPos, moveTime));
    }

    public Vector3? GetClickPosition()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
//                Debug.Log(hit.collider.gameObject.name);
                return hit.point;
            }
        }

        return null;
    }

    public IEnumerator MoveToInSeconds(Transform transformToMove, Vector3 endPos, float seconds)
    {
        float elaspedTime = 0;
        Vector3 startPos = transformToMove.position;
        endPos.y = startPos.y;
        while (elaspedTime < seconds)
        {
            elaspedTime += Time.deltaTime;
            transformToMove.position = Vector3.Lerp(startPos, endPos, elaspedTime / seconds);
            yield return null;
        }
    }

    public class MoveCommand : ICommand
    {
        private Transform transformToMove;
        private Vector3 displacement;

        public MoveCommand(Transform transformToMove, Vector3 displacement)
        {
            this.transformToMove = transformToMove;
            this.displacement = displacement;
        }

        public void Execute()
        {
            transformToMove.position += displacement;
        }

        public void Undo()
        {
            transformToMove.position -= displacement;
        }
    }

    public class MoveToCommand : ICommand
    {
        private GameManagerCommands gameManager;
        private Vector3 destination;
        private Vector3 startPos;

        public MoveToCommand(GameManagerCommands gameManager, Vector3 destination, Vector3 startPos)
        {
           
            this.destination = destination;
            this.startPos = startPos;
            this.gameManager = gameManager;
        }

        public void Execute()
        {
           
            gameManager.MoveTo(destination);
        }

        public void Undo()
        {
            gameManager.MoveTo(startPos);
        }
    }
}

public class CommandInvoker
{
    private Stack<ICommand> commands;
    private Stack<ICommand> undoCommands;

    public CommandInvoker()
    {
        commands = new Stack<ICommand>();
        undoCommands = new Stack<ICommand>();
    }

    public void Execute(ICommand command)
    {
        commands.Push(command);
        command.Execute();
    }

    public void Undo()
    {
        if (commands.TryPop(out ICommand command))
        {
            command.Undo();
            undoCommands.Push(command);
        }
    }

    public void Redo()
    {
        if (undoCommands.TryPop(out ICommand command))
        {
            command.Execute();
        }
    }
}

public interface ICommand
{
    void Execute()
    {
    }

    void Undo()
    {
    }
}