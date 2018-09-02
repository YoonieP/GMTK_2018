using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float frontSpeed = 3.2f;
    public float backSpeed = 2.7f;
    public float bulletSpeed = 3.5f;
    private float shootCooldownTimer = 0;
    public float shootCooldown = .3f;
    private AudioSource shootSound;
    private float[] possiblePitchHighs = { 0.9f, 0.95f, 1, 1.05f, 1.1f};
	// Use this for initialization
	void Start () {
        shootSound = GameObject.Find("ShootSound").GetComponent<AudioSource>(); 
	}
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime;
        z = z > 0 ? z * frontSpeed : z * backSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        if (Input.GetKeyDown(KeyCode.Space) && shootCooldownTimer >= shootCooldown)
        {
            shootCooldownTimer = 0;
            shootBullet();
            GetComponent<Animator>().SetTrigger("shoot");
        }
        else if (shootCooldownTimer < shootCooldown)
        {
            shootCooldownTimer += Time.deltaTime;
        }
    }

    void shootBullet()
    {
        shootSound.Play();
        shootSound.pitch = possiblePitchHighs[Random.Range(0,possiblePitchHighs.Length)];
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position,bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        Destroy(bullet, 3f);
    }
}


