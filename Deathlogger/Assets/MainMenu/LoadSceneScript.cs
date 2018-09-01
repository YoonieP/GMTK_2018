using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneScript : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene("MikeScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
