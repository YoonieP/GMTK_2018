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
	
    void Start()
    {
        enemyArray = new GameObject[startingArraySize];
    }
	// Update is called once per frame
	void Update () {
        if (currentActiveEnemys != sameTimeActiveEnemys)
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
    }
}
