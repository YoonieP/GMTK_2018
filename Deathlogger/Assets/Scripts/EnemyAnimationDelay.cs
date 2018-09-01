using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationDelay : MonoBehaviour {
    private float timeCounter = 5;
    private float[] animatorSpeeds = { 0.9f, 0.95f, 1f, 1.05f, 1.1f };
	
	// Update is called once per frame
	void Update () {
        timeCounter += Time.deltaTime;
        if(timeCounter > 5)
        {
            timeCounter = 0;
            transform.GetChild(0).GetComponent<Animator>().speed = animatorSpeeds[Random.Range(0,animatorSpeeds.Length)];
        }
	}
}
