using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IHealable<float>
{
    public float health = 2;
    public float maxHealth = 100; 
    
    public void Heal(float points)
    {
        health += points;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
