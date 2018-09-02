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
    private AudioClip spiderWalk1;
    private float startAudioTimer;
    private float waitForAudio;
    private bool soundStarted = false;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        goal = GameObject.FindWithTag("Player").GetComponent<Transform>();
        agent.destination = goal.position;
        spiderWalk1 = GetComponent<AudioClip>();
        if (Random.Range(0, 10) > 5)
        {
            GetComponent<AudioSource>().clip = spiderWalk2;            
        }else
        {
            GetComponent<AudioSource>().clip = spiderWalk1;
        }
        waitForAudio = Random.Range(0f, 3f);
    }
    

    void Update()
    {
        startAudioTimer += Time.deltaTime;
        if (startAudioTimer >= waitForAudio && !soundStarted)
        {
            soundStarted = true;
            GetComponent<AudioSource>().Play();
        }        
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