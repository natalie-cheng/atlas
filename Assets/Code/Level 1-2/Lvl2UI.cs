using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl2UI : MonoBehaviour
{
    public static Lvl2UI Singleton;
    public TextMeshProUGUI scoreText;
    public GameObject endScreen;
    public TextMeshProUGUI endText;

    // Start is called before the first frame update
    void Start()
    {
        Singleton = this;

        scoreText.text = Atlas.health + "";
        endScreen.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Atlas.health<0)
        {
            GameOver(false);
        }
        else if (Atlas.xPos > 9.5)
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

    public static void changeHealth(float dmg)
    {
        Singleton.changeHealthInternal(dmg);
    }

    private void changeHealthInternal(float dmg)
    {
        Atlas.health -= dmg;
        scoreText.text = Atlas.health + "";
    }

    // load transition to next level
    public void LoadNextLevel()
    {
        GameUI.levelTrack += 1;
        SceneManager.LoadScene("Transition");
    }
}
