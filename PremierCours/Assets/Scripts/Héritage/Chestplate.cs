using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Chestplate : Armor
{
    public int ChestSize;
    public Chestplate(int _id, string _itemName, string _description, int _value, 
        int _currentDurability, int _maxDurability, int _weight, ItemRaretyEnum _rarity,
        int _physicalDamageReduction, int _fireDamageReduction, int _electrictyDamageReduction,
        int _poisonDamageReduction,  int _chestSize) : base(_id, _itemName, _description, _value, _currentDurability,
        _maxDurability, _weight, _rarity, _physicalDamageReduction, _fireDamageReduction, _electrictyDamageReduction, _poisonDamageReduction)
    {
        ChestSize = _chestSize;
    }
}
