using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public int damage;
    public int range;
    public float fireRate;
    public bool automatic;
    bool canFire = true;
    public float reloadTime;
    public int bulletInClip;
    public int clipSize;

    public RaycastHit hit;

	void Update ()
    {
        if(Input.GetButtonDown("Fire1") == true && canFire == true)
        {
            Shoot();

            StartCoroutine("TimeBetweenShots");
            Debug.Log("enumerator");
        }
	}

    public virtual IEnumerator TimeBetweenShots()
    {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

    public virtual void Shoot()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if(hit.transform.tag == "Zombie")
            {
                Debug.Log("hit");
                hit.transform.GetComponent<ZombieScript>().health -= damage;
            }
        }
        canFire = false;
        Debug.Log("Gun Fired");
    }
}
