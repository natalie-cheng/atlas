using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class Lvl3UI : MonoBehaviour
{
    public static Lvl3UI Singleton;
    public float health = 100f;
    public GameObject winScreen;
    public GameObject lossScreen;
    public GameObject instructions;
    public Image healthBar;

    public static int numBirds;


    // Start is called before the first frame update
    void Start()
    {
        GameUI.levelTrack = 3;

        Singleton = this;
        winScreen.SetActive(false);
        lossScreen.SetActive(false);
        instructions.SetActive(true);
        Time.timeScale = 0;

        Atlas_Level3.health = 100;

        numBirds = GameObject.FindGameObjectsWithTag("Bird_1").Length + GameObject.FindGameObjectsWithTag("Bird").Length;
    }

    // Update is called once per frame
    void Update()
    {
        // if all the birds are killed, then win
        if (numBirds<=0)
        {
            GameOver(true);
        }
    }

    public static void changeHealth(float dmg)
    {
        Singleton.changeHealthInternal(dmg);
    }

    private void changeHealthInternal(float dmg)
    {
        Atlas_Level3.health -= dmg;

        // change health bar fill
        healthBar.fillAmount -= dmg / Atlas_Level3.maxHealth;

        if (Atlas_Level3.health <= 0)
        {
            GameOver(false);
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
        SceneManager.LoadScene("Level 3");
    }
}
