using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    // UI object
    public static GameUI Singleton;

    public static int levelTrack;

    private void Start()
    {
        levelTrack = 0;
    }

    // load transition to next level
    public void LoadLevel()
    {
        SceneManager.LoadScene("Transition");
    }

    // instructions button
    //public void Instructions()
    //{
    //    SceneManager.LoadScene("Instructions");
    //}

    // menu button
    //public void Menu()
    //{
    //    SceneManager.LoadScene("MainMenu");
    //}

    // quit button
    //public void Quit()
    //{
    //    Application.Quit();
    //}
}
