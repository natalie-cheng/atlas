using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneUI : MonoBehaviour
{
    // load menu
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
