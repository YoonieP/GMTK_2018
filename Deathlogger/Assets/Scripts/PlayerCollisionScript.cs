using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("die");
            Object.FindObjectOfType<DeathCamScript>().camDrop();
        }
    }
}
