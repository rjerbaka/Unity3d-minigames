using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUpScreenController : MonoBehaviour
{   
    //Quit Game
    public void Quit()
    {
        Application.Quit();
    }

    //Start Game
    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }
}
