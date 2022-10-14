using System;
using UnityEngine;


[Serializable]
public class Armor : Item
{
   
   public Armor(int _id, string _itemName, string _description,int _value, int _currentDurability,int _maxDurability,int _weight,ItemRaretyEnum _rarity,
      int _physicalDamageReduction,int _fireDamageReduction, int _electrictyDamageReduction, int _poisonDamageReduction) : 
      base( _id, _itemName, _description, _value, _currentDurability, _maxDurability,_weight, _rarity)
   {
      PhysicalDamageReduction = _physicalDamageReduction;
      FireDamageReduction = _fireDamageReduction;
      ElectrictyDamageReduction = _electrictyDamageReduction;
      PoisonDamageReduction = _poisonDamageReduction;
   }
   public int PhysicalDamageReduction;
   public int FireDamageReduction;
   public int ElectrictyDamageReduction;
   public int PoisonDamageReduction;

   public void TakeDamage()
   {
      CurrentDurability--;
      Debug.Log("current durability " +CurrentDurability);
   }
}
