using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiShotgun : Shotgun
{
    public override void Reload()
    {
        StartCoroutine("ReloadTime");
    }

    public override IEnumerator ReloadTime()
    {
        canFire = false;
        yield return new WaitForSeconds(reloadTime);
        ammo--;
        bulletInClip++;
        canFire = true;
        Debug.Log("reloaded 1 shell");

        if(bulletInClip < clipSize)
        {
            Reload();
        }
    }

}
