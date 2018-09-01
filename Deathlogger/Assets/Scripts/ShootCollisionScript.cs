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
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            Object.FindObjectOfType<UIScript>().increasePoints(1);
        }
    }
}
