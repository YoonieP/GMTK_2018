﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float speed = 3.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootBullet();
        }
    }

    void shootBullet()
    {

        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position,bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 2;
        Destroy(bullet, 3f);
    }
}


