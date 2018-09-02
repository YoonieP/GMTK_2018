using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveTo : MonoBehaviour
{
    private Transform goal;
    private NavMeshAgent agent;
    private float timeCounter = 5;
    private float[] walkingSpeed = {2.3f, 2.5f, 2.8f,3f, 3.2f };
    private SpawnerScript spawner;
    public AudioClip spiderWalk2;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        goal = GameObject.FindWithTag("Player").GetComponent<Transform>();
        agent.destination = goal.position;
        if (Random.Range(0, 10) > 5)
        {
            GetComponent<AudioSource>().clip = spiderWalk2;
            GetComponent<AudioSource>().Play();
        }       
    }
    

    void Update()
    {
        agent.destination = goal.position;
        timeCounter += Time.deltaTime;
        if (timeCounter > 5)
        {
            timeCounter = 0;
            agent.speed = walkingSpeed[Random.Range(0, walkingSpeed.Length)];
        }
    }

    public void setGoal(Transform newGoal)
    {
        goal = newGoal;
    }

    public void setSpawner(SpawnerScript sp)
    {
        spawner = sp;
    }

    public void spawnerDecreaseCurrentActiveEnemys()
    {
        spawner.decreaseCurrentActiveEnemys();
    }
}