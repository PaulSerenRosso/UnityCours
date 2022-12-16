using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeathManager : MonoBehaviour
{
    private float health = 100;
    public UnityEvent onPlayerDeath;
    public FloatEvent onPlayerHurt;

    public void TakeDamage(float damage)
    {
        health -= damage;
        onPlayerHurt.Invoke(damage);

        if (health < 0)
        {
            onPlayerDeath.Invoke();
        }
    }
}

[System.Serializable]
public class FloatEvent : UnityEvent<float> {}