using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.ParticleSystem;

public class Beetle : MonoBehaviour
{
    [SerializeField] Transform rose;
    private NavMeshAgent beetle;

    private void Start()
    {
        beetle = GetComponent<NavMeshAgent>();
        beetle.enabled = false;
    }
    private void Update()
    {
        Vector3 directionToPlayer = rose.position - transform.position;
        Vector3 oppositeDirection = transform.position - directionToPlayer;
        if (!BeetleTrigger.isSpawning)
        {
            beetle.enabled = false;
            beetle.SetDestination(rose.position);
        }
        else
        {
            beetle.SetDestination(oppositeDirection);
        }
    }
}
