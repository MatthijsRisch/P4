using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject zombie;
    public float spawTime;
    public bool spawnCheck;

    void Start()
    {
        spawnCheck = true;
    }

    void Update()
    {
        if (spawnCheck == true)
        {
            StartCoroutine(Spawner());
            spawnCheck = false;
            Debug.Log("Sawn");
        }
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(spawTime);
        Instantiate(zombie, transform.position, transform.rotation);
        spawnCheck = true;
        Debug.Log("Ie werkt");
    }
}
