using System;

[Serializable]
public class ItemInventory
{
    public string Name;
    public string Description;
    public ItemTypeEnum[] itemTypeEnums;
    public void SetAction()
    {
        Actions = new IUsable[itemTypeEnums.Length];
        for (int i = 0; i < itemTypeEnums.Length; i++)
        {
            switch (itemTypeEnums[i])
            {
                case ItemTypeEnum.Consumable:
                {
                    Actions[i] = new ConsumedItemAction();
                    break;
                }
                case ItemTypeEnum.Equipable:
                {
                    Actions[i] = new EquipedItemAction();
                    break;
                }
                case ItemTypeEnum.Relatable:
                {
                    Actions[i] = new RelatedItemAction();
                    break;
                }
            }
        }
    }
    public IUsable[] Actions;
}