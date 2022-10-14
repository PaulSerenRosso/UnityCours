using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
  [SerializeField] private Transform target;

  [SerializeField] private float healPoints;
  [SerializeField] private KeyCode healKey = KeyCode.A;

  private void Update()
  {
    if (Input.GetKeyDown(healKey))
    {
        IHealable<float> healableFloat = target.GetComponent<IHealable<float>>();
        if (healableFloat != null)
        {
            healableFloat.Heal(healPoints);
        }
        
        IHealable<int> healableInt = target.GetComponent<IHealable<int>>();
        if (healableInt != null)
        {
            healableInt.Heal(Mathf.FloorToInt(healPoints));
        }
    }
  }
}
