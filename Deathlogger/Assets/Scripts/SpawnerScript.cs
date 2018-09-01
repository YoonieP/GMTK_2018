using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {
    public int sameTimeActiveEnemys = 2;
    public int currentActiveEnemys = 0;
    public int startingArraySize = 20;
    public GameObject[] enemyArray;
    public GameObject enemy1;
    public GameObject enemy2;
    public float timeTillActiveEnemysIncreases = 30;    //seconds
    private float timeCounter;
    private float spawnCouldownTimer = 6;
    private float spawnCouldownMinimum = 4;
    void Start()
    {
        enemyArray = new GameObject[startingArraySize];
    }
	// Update is called once per frame
	void Update () {
        timeCounter += Time.deltaTime;
        spawnCouldownTimer += Time.deltaTime;
        if (timeCounter >= timeTillActiveEnemysIncreases)
        {
            timeCounter = 0;
            currentActiveEnemys++;
        }
        if (currentActiveEnemys != sameTimeActiveEnemys && spawnCouldownTimer >= spawnCouldownMinimum)
        {            
            for (int i = 0; i < (sameTimeActiveEnemys-currentActiveEnemys); i++)
            {
                if (Random.value > 0.5)
                {
                    GameObject en1 = Instantiate(enemy1, transform);
                    en1.GetComponent<EnemyMoveTo>().setSpawner(this);
                    enemyArray[i] = en1;
                }
                else
                {
                    GameObject en2 = Instantiate(enemy2, transform);
                    en2.GetComponent<EnemyMoveTo>().setSpawner(this);
                    enemyArray[i] = en2;
                }
                currentActiveEnemys++;
            }
        }
    }

    public void decreaseCurrentActiveEnemys()
    {
        currentActiveEnemys--;
        spawnCouldownTimer = 0;
    }
}
