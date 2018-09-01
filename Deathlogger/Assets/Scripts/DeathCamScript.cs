using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCamScript : MonoBehaviour {

	public void camDrop() {
        GetComponent<BoxCollider>().enabled = true;
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.constraints = RigidbodyConstraints.None;
	}
}
