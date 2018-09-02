using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour {
    public UIScript script;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(script.points > 5 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            new WaitForSeconds(2);
            SceneManager.LoadScene(1);
        }
	}
}
