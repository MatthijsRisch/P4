using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : WeaponBase
{
	void Start ()
    {
		
	}

    private void Update()
    {

    }

    public override void Shoot()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.red);

    }
}
