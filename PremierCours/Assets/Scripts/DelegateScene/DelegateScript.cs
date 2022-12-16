using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateScript : MonoBehaviour
{
    delegate void Attack();

    private Attack attack;

    [SerializeField] AttackType currentAttackType;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
          GetTypeAttack();
          SetTypeAttack();
        }
      
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            attack?.Invoke();
        }
    }

    void Burn()
    {
        Debug.Log("burn");
    }

   public  enum AttackType
    {
        Burn,Freeze,Multicast
    }

   void GetTypeAttack()
   {
    
     currentAttackType = (AttackType)(((int)currentAttackType + 1) % System.Enum.GetValues(typeof(AttackType)).Length);
   }

   void SetTypeAttack()
   {
       switch (currentAttackType)
       {
           case AttackType.Burn:
           {
               attack = Burn;
               break;
           }
           case AttackType.Freeze:
           {
               attack = Freeze;
               break;
           }
           case AttackType.Multicast:
           {
               attack = Freeze;
               attack += Burn;
               break;
           }
       }
   }

    
    void Freeze()
    {
        Debug.Log("freeze");
    }
    
}
