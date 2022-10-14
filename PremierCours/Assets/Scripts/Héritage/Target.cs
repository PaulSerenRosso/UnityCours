using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private float health;

    public void TakeDamage(float _damageAmount)
    {
        health -= _damageAmount;
        Debug.Log(health);
      
    }
    
}
