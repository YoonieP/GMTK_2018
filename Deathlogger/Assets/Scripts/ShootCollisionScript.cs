using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCollisionScript : MonoBehaviour {
    private UIScript uiScript;
    private bool collidedWithEnemy = false;
    public AudioClip willhelm;
    public AudioClip robotDeathSound;
    private void Start()
    {
        uiScript = GetComponent<UIScript>();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            if(Random.Range(0,500) == 42)
            {
                collision.gameObject.GetComponent<AudioSource>().clip = willhelm;
            }
            else
            {
                collision.gameObject.GetComponent<AudioSource>().clip = robotDeathSound;
            }
            collision.gameObject.GetComponent<AudioSource>().loop = false;
            collision.gameObject.GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            collision.gameObject.GetComponent<EnemyMoveTo>().setGoal(collision.gameObject.transform);
            collision.gameObject.GetComponent<EnemyMoveTo>().spawnerDecreaseCurrentActiveEnemys();
            if(collision.gameObject.transform.childCount>0)
                collision.gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("death",true);            
            Destroy(collision.gameObject, 3f);
            Object.FindObjectOfType<UIScript>().increasePoints(1);
            Object.FindObjectOfType<PlayerReactionsScript>().playEnemyHit();
            collidedWithEnemy = true;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "terrain")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (!collidedWithEnemy)
        {
            Object.FindObjectOfType<PlayerReactionsScript>().increaseEnemyMissCounter();
        }
    }
}
