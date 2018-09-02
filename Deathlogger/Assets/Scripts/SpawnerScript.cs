using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {
    public int sameTimeActiveEnemys = 2;
    public int currentActiveEnemys = 0;
    public GameObject enemy1;
    public GameObject enemy2;
    public float timeTillActiveEnemysIncreases = 30;    //seconds
    private float timeCounter;
    private float spawnCouldownTimer = 6;
    private float spawnCouldownMinimum = 2;
    private float timerBetweenSpawnCounter = 0;
	// Update is called once per frame
	void Update () {
        timeCounter += Time.deltaTime;
        timerBetweenSpawnCounter += Time.deltaTime;
        spawnCouldownTimer += Time.deltaTime;
        if (timeCounter >= timeTillActiveEnemysIncreases)
        {
            timeCounter = 0;
            sameTimeActiveEnemys++;
        }
        if (currentActiveEnemys != sameTimeActiveEnemys && spawnCouldownTimer >= spawnCouldownMinimum && timerBetweenSpawnCounter>=1)
        {            
           // for (int i = 0; i < (sameTimeActiveEnemys-currentActiveEnemys); i++)
           // {
                if (Random.value > 0.5)
                {
                    GameObject en1 = Instantiate(enemy1, transform);
                    en1.GetComponent<EnemyMoveTo>().setSpawner(this);
                }
                else
                {
                    GameObject en2 = Instantiate(enemy2, transform);
                    en2.GetComponent<EnemyMoveTo>().setSpawner(this);
                }
                currentActiveEnemys++;
                timerBetweenSpawnCounter = 0;
            //}
        }
    }

    public void decreaseCurrentActiveEnemys()
    {
        currentActiveEnemys--;
        spawnCouldownTimer = 0;
    }
}
