using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IHealable<int>, IHealable<float>
{
    [SerializeField] private int health = 10;

    void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int points)
    {
        health -= points*2;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(float points)
    {
        health -= (int) points*8;
        if (health <= 0)
        {
            Die();
        }
    }
}
