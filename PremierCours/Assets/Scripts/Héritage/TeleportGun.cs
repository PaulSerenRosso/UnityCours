using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportGun : Gun
{
 protected override void Shoot()
 {
  base.Shoot();
  Vector3 newPosition = transform.position + Random.insideUnitSphere * damage;
  target.transform.position = newPosition;
 }
}
