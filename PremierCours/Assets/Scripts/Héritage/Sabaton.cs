using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sabaton : Armor
{
    public int FootSize;
    public Sabaton(int _id, string _itemName, string _description, int _value, 
        int _currentDurability, int _maxDurability, int _weight, ItemRaretyEnum _rarity,
        int _physicalDamageReduction, int _fireDamageReduction, int _electrictyDamageReduction,
        int _poisonDamageReduction, int _footSize) : 
        base(_id, _itemName, _description, _value, _currentDurability, _maxDurability, _weight,
            _rarity, _physicalDamageReduction, _fireDamageReduction, _electrictyDamageReduction, _poisonDamageReduction)
    {
        FootSize = _footSize;
    }
}
