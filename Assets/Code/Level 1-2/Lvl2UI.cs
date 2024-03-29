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

    private AudioSource sfx;
    public AudioClip winSfx;
    public AudioClip loseSfx;
    public AudioClip dmgSfx;

    // Start is called before the first frame update
    void Start()
    {
        GameUI.levelTrack = 2;
        Singleton = this;

        AtlasLvl2.health = 100;
        winScreen.SetActive(false);
        lossScreen.SetActive(false);
        instructions.SetActive(true);
        Time.timeScale = 0;

        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AtlasLvl2.xPos > 52)
        {
            GameOver(true);
        }
    }

    private void GameOver(bool win)
    {
        Time.timeScale = 0;
        if (win)
        {
            sfx.PlayOneShot(winSfx);
            winScreen.SetActive(true);
        }
        else
        {
            sfx.PlayOneShot(loseSfx);
            lossScreen.SetActive(true);
        }
    }

    public static void changeHealth(float dmg)
    {
        Singleton.changeHealthInternal(dmg);
    }

    private void changeHealthInternal(float dmg)
    {
        AtlasLvl2.health -= dmg;
        sfx.PlayOneShot(dmgSfx,1);

        // change health bar fill
        healthBar.fillAmount -= dmg / AtlasLvl2.maxHealth;

        if (AtlasLvl2.health <= 2)
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
