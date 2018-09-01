using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathCamScript : MonoBehaviour {

	public void camDrop() {
        StartCoroutine(ChangeToScene());        
    }

         public IEnumerator ChangeToScene()
     {
        GameObject.Find("EndScoreCanvas").GetComponent<Canvas>().enabled = true;
        GameObject.Find("EndScore").GetComponent<Text>().text = "You died\r\nYour Followers, will always remember you\r\nfor killing "+Object.FindObjectOfType<UIScript>().getPoints()+" Robots"; 
        GetComponent<BoxCollider>().enabled = true;
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.constraints = RigidbodyConstraints.None;
        Object.FindObjectOfType<PlayerMovementScript>().enabled = false;
        Object.FindObjectOfType<PlayerMovementScript>().gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Object.FindObjectOfType<PlayerReactionsScript>().playDeathSound();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
