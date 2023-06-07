using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class DataManager : MonoBehaviour
{
   
    [SerializeField]
    private Faction faction;
  public  void GenerateData()
    {
        faction = new Faction();
        faction.platoons = new Platoon[5];
        for (int i = 0; i < faction.platoons.Length; i++)
        {
            faction.platoons[i] = new Platoon();
        }
        foreach (var platoon in faction.platoons)
        {
            platoon.units = new PlatoonUnit[100];
            for (int i = 0; i < platoon.units.Length; i++)
            {
                platoon.units[i] = new PlatoonUnit();
            }
            foreach (var unit in platoon.units)
            {
                unit.hp = 100;
                unit.strengh = Random.Range(0, 50);
            }
        }
    }

  public void Save()
  {
      DataSerializer.instance.SaveDataOnMainDirectory(faction);
  }
  public void Load()
  {
      faction = DataSerializer.instance.LoadDataFromDirectory<Faction>();
  }
  
    
}

[Serializable]
public class Faction
{
    public Platoon[] platoons;
}
[Serializable]
public class Platoon
{
    public PlatoonUnit[] units;
}
[Serializable]
public class PlatoonUnit
{
    public int hp;

    public int strengh;
}
