using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReactionsScript : MonoBehaviour {
    public AudioClip[] playerDeath;
    public AudioClip[] enemyHit;
    public AudioClip[] enemyMiss;
    public AudioClip[] enemyClose;
    public AudioClip[] noEnemyAround;
    public AudioClip[] welcomeSpeech;
    private AudioSource audioSource;

    private int enemyMissCounter = 0;
    private float timerNoEnemyAround = 0;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = welcomeSpeech[Random.Range(0,welcomeSpeech.Length)];
        audioSource.Play();
	}

    private void Update()
    {
        timerNoEnemyAround += Time.deltaTime;
        if(timerNoEnemyAround > 30 && Random.Range(0,10)>8)
        {
            playnoEnemyAround();
            timerNoEnemyAround = 0;
        }
    }

    public void playDeathSound()
    {
        audioSource.clip = playerDeath[Random.Range(0, playerDeath.Length)];
        audioSource.Play();
    }
    public void playEnemyHit()
    {
        enemyMissCounter = 0;
        if (Random.Range(0, 10) > 4)
        {
            audioSource.clip = enemyHit[Random.Range(0, enemyHit.Length)];
            audioSource.Play();
        }
    }

    public void playEnemyMiss()
    {
        if (enemyMissCounter > 5 && Random.Range(0, 10) > 4)
        {
            enemyMissCounter = 0;
            audioSource.clip = enemyMiss[Random.Range(0, enemyMiss.Length)];
            audioSource.Play();
        }
    }

    public void playnoEnemyAround()
    {
        audioSource.clip = noEnemyAround[Random.Range(0, noEnemyAround.Length)];
        audioSource.Play();
    }

    public void playEnemyClose()
    {
        if (Random.Range(0, 10) > 2)
        {
            audioSource.clip = enemyClose[Random.Range(0, enemyClose.Length)];
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            timerNoEnemyAround = 0;
            playEnemyClose();
        }
    }

    public void increaseEnemyMissCounter()
    {
        enemyMissCounter++;
    }
}