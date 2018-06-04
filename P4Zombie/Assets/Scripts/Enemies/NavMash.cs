using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMash : MonoBehaviour
{
    NavMeshAgent zombie;
    Transform Player;

	void Start ()
    {
        zombie = this.GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("Player").transform;
        
    }

    void Update()
    {
        zombie.SetDestination(Player.position);
    }
}
