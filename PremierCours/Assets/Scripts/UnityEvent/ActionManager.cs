using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ActionManager : MonoBehaviour
{
    public List<ActionByProbability> actionByProbabilities = new List<ActionByProbability>();

    public float totalProbability;
    public void ChangeWeatherToRain()
    {
        Debug.Log("It's raining");
    }

    public void EveryBodyLose10HP()
    {
        Debug.Log("EveryBody lose 10 hp");
    }

    public void TheLastPlayGainInvincibility()
    {
        Debug.Log("");
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        actionByProbabilities = new List<ActionByProbability>()
        {
            new ActionByProbability(
            )
            {
                action = ChangeWeatherToRain,
                    probability = 1
            },
            new ActionByProbability(
            )
            {
                action = EveryBodyLose10HP,
                probability = 3
            },
            new ActionByProbability(
            )
            {
                action = TheLastPlayGainInvincibility,
                probability = 2
            },
        };
        foreach (var actionByProbability in actionByProbabilities)
        {
            totalProbability += actionByProbability.probability;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            CallRandomAction();
        }
    }

    private void CallRandomAction()
    {
       float rn = Random.Range(0, totalProbability);
       float currentProbabilitySum = 0;

       for (int i = 0; i < actionByProbabilities.Count; i++)
       {
           currentProbabilitySum += actionByProbabilities[i].probability;
           if (rn < currentProbabilitySum)
           {
               actionByProbabilities[i].action?.Invoke();
           }
       }
    }

    public struct ActionByProbability
    {
        public Action action;

        public float probability;
    }
}