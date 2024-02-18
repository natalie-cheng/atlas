using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TransitionUI : MonoBehaviour
{
    // UI object
    public static TransitionUI Singleton;

    // text object
    public TextMeshProUGUI textContent;

    private string scene;

    private void Start()
    {
        LoadText(GameUI.levelTrack);
    }

    private void LoadText(int level)
    {
        if (level==1)
        {
            textContent.text = "this is level 1 content";
            scene = "Level 1";
        }
        else if (level == 2)
        {
            textContent.text = "this is level 2 content";
            scene = "Level 2";
        }
        else if (level == 3)
        {
            textContent.text = "this is level 3 content";
            scene = "Level 3";
        }
        else if (level == 4)
        {
            textContent.text = "this is level 4 content";
            scene = "Level 4";
        }
        else if (level == 5)
        {
            textContent.text = "this is level 5 content";
            scene = "Level 5";
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
