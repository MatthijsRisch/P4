using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public int health;
    public int currency;

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
