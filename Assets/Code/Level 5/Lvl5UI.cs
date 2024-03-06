using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class Lvl5UI : MonoBehaviour
{
    public static Lvl5UI Singleton;
    public TextMeshProUGUI timerText;
    public GameObject winScreen;
    public GameObject lossScreen;
    public GameObject instructions;
    public Image healthBar;

    private AudioSource sfx;
    public AudioClip winSfx;
    public AudioClip loseSfx;

    // total timer time
    private float totalTime = 61f;
    // track current time
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        GameUI.levelTrack = 5;
        Singleton = this;

        // set the time
        currentTime = totalTime;

        Atlas_Level5.health = 100;
        winScreen.SetActive(false);
        lossScreen.SetActive(false);
        instructions.SetActive(true);
        Time.timeScale = 0;

        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // update timer
        currentTime -= Time.deltaTime;

        if (currentTime <= 1f)
        {
            GameOver(true);
        }

        // calculate time
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // display time
        timerText.text = "Time: " + (minutes > 0 ? minutes.ToString() : "0") + ":" + (seconds >= 10 ? seconds.ToString() : "0" + seconds.ToString());

    }

    public static void AtlasChangeHealth(float dmg)
    {
        Singleton.ChangeHealthInternal(dmg);
    }

    private void ChangeHealthInternal(float dmg)
    {
        Atlas_Level5.health -= dmg;

        // change health bar fill
        healthBar.fillAmount -= dmg / Atlas_Level5.maxHealth;

        if (Atlas_Level5.health <= 0)
        {
            GameOver(false);
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

    // start level
    public void Play()
    {
        instructions.SetActive(false);
        Time.timeScale = 1;
    }

    // load transition to next level
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("EndScene");
    }

    // back to main menu
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Replay()
    {
        SceneManager.LoadScene("Level 5");
    }
}
