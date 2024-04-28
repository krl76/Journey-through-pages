using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.ParticleSystem;

public class Beetle : MonoBehaviour
{
    [SerializeField] Transform rose;
    [SerializeField] private GameObject beetleTrigger;
    public GameObject beetleGO;
    [SerializeField] private NavMeshAgent beetle;
    private BeetleTrigger trigger;
    private bool isSpawning;
    private bool isTimerOut;
    private void Awake()
    {
        trigger = beetleTrigger.GetComponent<BeetleTrigger>();
    }
    private void Start()
    {
        beetle = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        isSpawning = trigger.isSpawning;
        isTimerOut = trigger.isTimerOut;
        Vector3 directionToRose = rose.position - transform.position;
        Vector3 oppositeDirection = transform.position - directionToRose;
        if (isSpawning && !isTimerOut)
        {
            beetle.SetDestination(oppositeDirection);
        }
        if (!isSpawning && isTimerOut)
        {
            beetle.SetDestination(rose.position);
        }
    }
}
