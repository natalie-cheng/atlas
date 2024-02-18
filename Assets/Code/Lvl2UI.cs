using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2UI : MonoBehaviour
{
    public static Lvl2UI Singleton;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Singleton = this;

        scoreText.text = Atlas.health + "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Atlas.health<0)
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
        Atlas.health -= dmg;
        scoreText.text = Atlas.health + "";
    }
}
