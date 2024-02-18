using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class Lvl2UI : MonoBehaviour
{
    public static Lvl2UI Singleton;
    public GameObject winScreen;
    public GameObject lossScreen;
    public GameObject instructions;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        GameUI.levelTrack = 2;
        Singleton = this;

        Atlas.health = 100;
        winScreen.SetActive(false);
        lossScreen.SetActive(false);
        instructions.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Atlas.xPos > 9.5)
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
        Atlas.health -= dmg;

        // change health bar fill
        healthBar.fillAmount -= dmg / Atlas.maxHealth;

        if (Atlas.health <= 0)
        {
            GameOver(false);
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
