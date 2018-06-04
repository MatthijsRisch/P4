using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : WeaponBase
{
    public override void Shoot()
    {
        Debug.DrawRay(transform.position, transform.forward * range, Color.green);
        base.Shoot();
    }
}
