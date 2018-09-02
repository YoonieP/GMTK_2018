using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour {
    float x;
    public GameObject fan;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        x += Time.deltaTime * 1.5f;
        fan.transform.Rotate(new Vector3(0, x, 0));

    }
}
