using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl1UI : MonoBehaviour
{
    // UI objects
    public static Lvl1UI Singleton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public GameObject winScreen;
    public GameObject lossScreen;
    public GameObject instructions;
    private AudioSource sfx;
    public AudioClip winSfx;
    public AudioClip loseSfx;

    // total timer time
    private float totalTime = 45f;
    // track current time
    private float currentTime;

    // plank number tracker
    private float numPlanks;

    // Start is called before the first frame update
    void Start()
    {
        GameUI.levelTrack = 1;
        Singleton = this;

        // set objects
        scoreText.text = "Planks: 0";
        numPlanks = 0;
        // set the time
        currentTime = totalTime;

        // set game beginning ui
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

        // if all planks are gotten
        if (numPlanks == 10)
        {
            GameOver(true);
        }

        // if time is up
        else if (currentTime <= 1f)
        {
            // game lose
            GameOver(false);
        }

        // calculate time
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // display time
        timerText.text = "Time: " + (minutes > 0 ? minutes.ToString() : "0") + ":" + (seconds >= 10 ? seconds.ToString() : "0" + seconds.ToString());
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

    public static void addPlank()
    {
        Singleton.addPlankInternal();
    }

    private void addPlankInternal()
    {
        numPlanks += 1;
        scoreText.text = "Planks: " + numPlanks;
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
        SceneManager.LoadScene("Level 1");
    }
}
