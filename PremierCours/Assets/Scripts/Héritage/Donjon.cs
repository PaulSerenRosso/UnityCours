using System;
using System.Collections;
using System.Collections.Generic;
using MonoLoopFunctions;
using UnityEngine;

public class Donjon : MonoBehaviour, IUpdatable
{
    // as use for reference and can be null ne renvoie pas d'erreur
    // (type) error
    // le point d'ancre pour l'ui cela correspond à la distance qui doit etre maintenant entre le point d'ancrache est l'objet
    private void Start()
    {
        UpdateManager.Register(this);
        Debug.Log("creating unit");
        Unit unit = new Unit(500);
        
        Skeleton skeleton = new Skeleton(999);
        unit.Die();
        skeleton.Die();
        Unit skeleton2 = new Skeleton(100);
        Murloc murloc = new Murloc();
        murloc.Die();
    }

    public void OnUpdate()
    {
       Debug.Log("bonsoir à tous");
    }
}
