using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lvl3UI : MonoBehaviour
{
    public static Lvl3UI Singleton;
    public TextMeshProUGUI scoreText;
    public float health = 100f;
    

    // Start is called before the first frame update
    void Start()
    {
        Singleton = this;
        scoreText.text = health + "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Atlas.health <= 0)
        {
            scoreText.text = "lose";
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
}
