using DelegateScene;
using UnityEngine;


public class PlayerHealthDelegate : MonoBehaviour, IDamageableDelegate
{
    [SerializeField] private int health = 100;

    public delegate void OnGameOver();

    public static OnGameOver onGameOver;

    public void TakeDamage(int damage)
    {
        Debug.Log("bonsoir à tous");
        health -= damage;
        if (health < 0)
        {
            Debug.Log("death");
            onGameOver?.Invoke();
        }
    }
}