using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Unit
{
    // il appelle le constructeur parent avant de meme qu'il s'execute
    public Skeleton()
    {
        hpMax = 5;
        Debug.Log("le skeleton est appelé et a " + hpMax);
    }
// base permet de spécifié le constructeur parent qu'on utilise
    public Skeleton(int _hpMax) : base(_hpMax)
    {
        Debug.Log("le second constructeur se lance");
    }
// l'opérateur new ecrase la fonction
    public override void Die()
    {
        base.Die();
        Debug.Log("disable ragdool and random force on each bone");
    }
}
