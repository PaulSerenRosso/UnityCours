using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Helmet : Armor
{
    public int HelmetSize;
    public Helmet(int _id, string _itemName, string _description,
        int _value, int _currentDurability, int _maxDurability,
        int _weight, ItemRaretyEnum _rarity, int _physicalDamageReduction,
        int _fireDamageReduction, int _electrictyDamageReduction, int _poisonDamageReduction, int _helmetSize) : base(_id, _itemName,
        _description, _value, _currentDurability, _maxDurability, _weight, _rarity, _physicalDamageReduction, _fireDamageReduction,
        _electrictyDamageReduction, _poisonDamageReduction)
    {
        HelmetSize = _helmetSize;
    }
}
