using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneScript : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene("TutorialLevel");
    }
    public void QuitGame()
    {
        Application.Quit();
    } 

}
