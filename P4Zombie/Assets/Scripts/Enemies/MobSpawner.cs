using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject zombie;
    public int spawTime;
    bool spawnCheck;

    void Start()
    {

    }

    void Update()
    {
        if (spawnCheck == true)
        {
            StartCoroutine(Spawner());
            spawnCheck = false;
        }
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(spawTime);
        Instantiate(zombie, transform.position, transform.rotation);
        spawnCheck = true;
    }
}
