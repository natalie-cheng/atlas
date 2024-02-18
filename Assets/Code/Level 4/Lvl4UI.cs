using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl4UI : MonoBehaviour
{
    public static Lvl4UI Singleton;
    public GameObject winScreen;
    public GameObject lossScreen;
    public GameObject instructions;

    // Start is called before the first frame update
    void Start()
    {
        GameUI.levelTrack = 4;
        Singleton = this;

        winScreen.SetActive(false);
        lossScreen.SetActive(false);
        instructions.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Boat.xPos <= -35)
        {
            GameOver(false);
        }
        else if (Boat.xPos >= 35)
        {
            GameOver(true);
        }
    }

    private void GameOver(bool win)
    {
        Time.timeScale = 0;
        if (win)
        {
            winScreen.SetActive(true);
        }
        else
        {
            lossScreen.SetActive(true);
        }
    }

    // start level
    public void Play()
    {
        instructions.SetActive(false);
        Time.timeScale = 1;
    }

    // load transition to next level
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Transition");
    }

    // back to main menu
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Replay()
    {
        SceneManager.LoadScene("Level 2");
    }
}
