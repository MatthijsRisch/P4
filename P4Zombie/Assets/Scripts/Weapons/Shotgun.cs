using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : WeaponBase
{
    public int pellets;
    Vector3 dir;
    Vector3 v;
    public float spread;

    public override void Shoot()
    {                 
        for (int i = 0; i < pellets; i++)
        {
            v.x = Random.Range(-spread, spread);
            v.y = Random.Range(-spread, spread);

            dir = transform.forward + v;

            Debug.DrawRay(transform.position, dir * range, Color.red, 10);
            if (Physics.Raycast(transform.position, dir, out hit, range))
            {
                if (hit.transform.tag == "Zombie")
                {
                    Debug.Log("hit");
                    hit.transform.GetComponent<ZombieScript>().health -= damage;
                    if (hit.transform.GetComponent<ZombieScript>().health <= 0)
                    {
                        GameObject.FindWithTag("Player").GetComponentInParent<PlayerController>().money += hit.transform.GetComponent<ZombieScript>().currency;
                        Debug.Log("cur ++");
                    }
                }
            }
        }
        canFire = false;
        bulletInClip -= 1;

        Debug.Log("Shotgun fired");
    }
}
