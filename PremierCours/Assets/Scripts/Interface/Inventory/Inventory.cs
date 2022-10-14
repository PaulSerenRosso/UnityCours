using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using MonoLoopFunctions;

public class Inventory : MonoBehaviour, IUpdatable
{
    [SerializeField] private List<ItemInventory> items = new List<ItemInventory>();
    [SerializeField] private KeyCode selectInputKey = KeyCode.I;
    [SerializeField] private ItemTypeButton[] itemTypeButtons;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    private ItemInventory currentItem;
    private IUpdatable _updatableImplementation;

    private void Start()
    {   
        UpdateManager.Register(this);

        InitializeItemsActions();
        InitializeItemTypeButtons();
    }

    private void OnDisable()
    { 
        UpdateManager.UnRegister(this);
    }

    void InitializeItemTypeButtons()
    {
        for (int i = 0; i < itemTypeButtons.Length; i++)
        {
            itemTypeButtons[i].Initialize();
        }
    }

    void InitializeItemsActions()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].SetAction();
        }
    }
    

    void CheckSelectItemInput()
    {
        if (Input.GetKeyDown(selectInputKey))
            SelectItem();
    }

    private void SelectItem()
    {
        for (int i = 0; i < itemTypeButtons.Length; i++)
        {
            itemTypeButtons[i].Deactive();
        }

        int rand = Random.Range(0, items.Count);
        currentItem = items[rand];
        PrintItemInformation();
    }

    private void PrintItemInformation()
    {
        descriptionText.text = currentItem.Description;
        nameText.text = currentItem.Name;
        PrintItemAction();
    }

    private void PrintItemAction()
    {
        for (int i = 0; i < currentItem.Actions.Length; i++)
        {
            Type currentType = currentItem.Actions[i].GetType();
            for (int j = 0; j < itemTypeButtons.Length; j++)
            {
                if (currentType == itemTypeButtons[j].ItemType)
                {
                    itemTypeButtons[i].Active();
                }
            }
        }
    }

    public void UseItem(Button button)
    {
        ItemTypeEnum typeEnum = ItemTypeEnum.Consumable;
        for (int i = 0; i < itemTypeButtons.Length; i++)
            if (button == itemTypeButtons[i].ItemButton)
            {
                typeEnum = itemTypeButtons[i].ItemTypeEnum;
            }
        int index = 0;
        for (int j = 0; j < currentItem.itemTypeEnums.Length; j++)
        {
            if (currentItem.itemTypeEnums[j] == typeEnum)
            {
                index = j;
            }
        }
        currentItem.Actions[index].Use();
    }

    public void OnUpdate()
    {
        CheckSelectItemInput();
        Debug.Log("bonsoir à fdqsfqdsf");
    }


 


}