using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCollisionScript : MonoBehaviour {
    private UIScript uiScript;

    private void Start()
    {
        uiScript = GetComponent<UIScript>();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            collision.gameObject.GetComponent<EnemyMoveTo>().setGoal(collision.gameObject.transform);            
            Destroy(collision.gameObject, 3f);
            Object.FindObjectOfType<UIScript>().increasePoints(1);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "terrain")
        {
            Destroy(gameObject);
        }
    }
}
