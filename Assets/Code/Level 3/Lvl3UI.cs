using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl3UI : MonoBehaviour
{
    public static Lvl3UI Singleton;
    public TextMeshProUGUI scoreText;
    public float health = 100f;
    public GameObject winScreen;
    public GameObject lossScreen;

    public static int numBirds;


    // Start is called before the first frame update
    void Start()
    {
        GameUI.levelTrack = 3;

        Singleton = this;
        scoreText.text = health + "";
        winScreen.SetActive(false);
        lossScreen.SetActive(false);
        Time.timeScale = 1;

        Atlas_Level3.health = 100;

        numBirds = GameObject.FindGameObjectsWithTag("Bird_1").Length + GameObject.FindGameObjectsWithTag("Bird").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Atlas_Level3.health <= 0)
        {
            GameOver(false);
        }
        // else if all the birds are killed, then win
        else if (numBirds<=0)
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

    public static void changeHealth(float dmg)
    {
        Singleton.changeHealthInternal(dmg);
    }

    private void changeHealthInternal(float dmg)
    {
        health -= dmg;
        scoreText.text = health + "";
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
        SceneManager.LoadScene("Level 3");
    }
}
