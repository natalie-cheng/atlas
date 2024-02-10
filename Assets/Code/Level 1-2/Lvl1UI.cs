using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl1UI : MonoBehaviour
{
    public static Lvl1UI Singleton;
    public TextMeshProUGUI scoreText;
    public GameObject endScreen;
    public TextMeshProUGUI endText;

    private float numPlanks;

    // Start is called before the first frame update
    void Start()
    {
        Singleton = this;

        scoreText.text = "0";
        numPlanks = 0;
        endScreen.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (numPlanks == 10)
        {
            GameOver(true);
        }
    }

    private void GameOver(bool win)
    {
        Time.timeScale = 0;
        endScreen.SetActive(true);
        if (win)
        {
            endText.text = "you won";
        }
        else
        {
            endText.text = "you lost";
        }
    }

    public static void addPlank()
    {
        Singleton.addPlankInternal();
    }

    private void addPlankInternal()
    {
        numPlanks += 1;
        scoreText.text = numPlanks +"";
    }

    // load transition to next level
    public void LoadNextLevel()
    {
        GameUI.levelTrack += 1;
        SceneManager.LoadScene("Transition");
    }
}
