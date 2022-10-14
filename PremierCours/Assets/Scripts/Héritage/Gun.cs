using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] protected Target target;
    [SerializeField]
    protected float range;

    [SerializeField]
    protected  float fireRate;

    [SerializeField] protected  float damage;

    [SerializeField] protected  Animation animation;
    
  
    
    private void Start()
    {
        StartCoroutine(LoopShoot());
    }

    protected virtual void Shoot()
    {
        target.TakeDamage(damage);
    animation.Play();
    }

    IEnumerator LoopShoot()
    {
     Shoot();
     yield return new WaitForSeconds(fireRate);
     StartCoroutine(LoopShoot());
    }

 
}
