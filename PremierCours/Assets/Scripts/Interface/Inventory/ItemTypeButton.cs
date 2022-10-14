using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemTypeButton
{
        
    public Type ItemType;
    public Button ItemButton;
    public ItemTypeEnum ItemTypeEnum;
    
    public ItemTypeButton(Button _itemButton, ItemTypeEnum _itemTypeEnum)
    {
        ItemButton = _itemButton;
        ItemTypeEnum = _itemTypeEnum;
    }

    public void Initialize()
    {
        Deactive();  
        switch (ItemTypeEnum)
        {
            case ItemTypeEnum.Consumable:
            {
                ItemType = typeof(ConsumedItemAction);
                break;
            }
            case ItemTypeEnum.Equipable:
            {
                ItemType = typeof(EquipedItemAction);
                break;
            }
            case ItemTypeEnum.Relatable:
            {
                ItemType = typeof(RelatedItemAction);
                break;
            }
        }
    }

    public void Active()
    {
        ItemButton.gameObject.SetActive(true);
    }

    public void Deactive()
    {
        ItemButton.gameObject.SetActive(false);
    }
}
