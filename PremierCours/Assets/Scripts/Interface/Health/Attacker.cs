using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private int damage = 1;

    [SerializeField] private KeyCode attackKey = KeyCode.Space;
    // Start is called before the first frame update
    void Start()
    {
    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            IDamageable damageable = target.GetComponent<IDamageable>();
            if(damageable!=null)
                damageable.TakeDamage(damage);
        }
            
    }
}