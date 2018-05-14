using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public int damage;
    public int range;
    public float fireRate;
    public bool automatic;
    bool canFire;
    public float reloadTime;
    public int bulletInClip;
    public int clipSize;

    public RaycastHit hit;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (canFire == false)
        {
            TimeBetweenShots(fireRate);
        }
	}

    public virtual IEnumerator TimeBetweenShots(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canFire = true;
    }


    public virtual void Shoot()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if(hit.transform.tag == "Zombie")
            {
                Debug.Log("hit");
            }
        }
        Debug.DrawRay(transform.position, transform.forward * 100, Color.gray);

        canFire = false;
    }
}
