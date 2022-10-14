using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntigravityGun : Gun
{
  protected override void Shoot()
  {
    base.Shoot();
    Rigidbody rbTarget = target.GetComponent<Rigidbody>();
    if (rbTarget != null)
    {
    target.GetComponent<Rigidbody>().useGravity = false;
    Vector3 force =  Random.insideUnitSphere * damage;
    rbTarget.AddForce(force);
    }
  }
}
