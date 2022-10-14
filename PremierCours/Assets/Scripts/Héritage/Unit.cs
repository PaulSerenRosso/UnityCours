
using UnityEngine;

public class Unit 
{
    public int hpMax;

    public Unit()
    {
        hpMax = 100;
        Debug.Log("le premier contructeur est appelé à "+hpMax);
    }

    public Unit(int _hpMax)
    {
        hpMax = _hpMax;
        Debug.Log("le premier contructeur est appelé à "+hpMax);
    }

    public virtual void Die()
    {
        Debug.Log("l'untié est morte");
    }
}
