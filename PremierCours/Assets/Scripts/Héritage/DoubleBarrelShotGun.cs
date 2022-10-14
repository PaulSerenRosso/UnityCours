using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBarrelShotGun : Gun
{
    protected override void Shoot()
    {
        base.Shoot();
        target.TakeDamage(damage);
    }
}
