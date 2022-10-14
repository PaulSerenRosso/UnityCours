using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Item
{
   public Item(int _id, string _itemName, string _description,int _value, int _currentDurability,int _maxDurability,int _weight,ItemRaretyEnum _rarity)
   {
      Id = _id;
      ItemName = _itemName;
      Description = _description;
      Value = _value;
      CurrentDurability = _currentDurability;
      Weight = _weight;
      MaxDurability = _maxDurability;
      Rarity = _rarity; 
   }
   public int Id;
   public string ItemName;
   public string Description;
   public int Value;
   public int CurrentDurability;
   public int MaxDurability;
   public int Weight;
   public ItemRaretyEnum Rarity; 
}
