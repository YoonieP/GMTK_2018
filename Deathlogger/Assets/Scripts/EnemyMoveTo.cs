using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveTo : MonoBehaviour
{
    private Transform goal;
    private NavMeshAgent agent;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        goal = GameObject.FindWithTag("Player").GetComponent<Transform>();
        agent.destination = goal.position;
    }

    void Update()
    {
        agent.destination = goal.position;
    }

    public void setGoal(Transform newGoal)
    {
        goal = newGoal;
    }
}