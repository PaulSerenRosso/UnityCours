using UnityEngine;

namespace DelegateScene
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private GameObject target;
        [SerializeField] private int damage = 10;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {Debug.Log("bonsoir je test");
           
                target.GetComponent<IDamageableDelegate>().TakeDamage(damage);
            
            }
        }
    }
}