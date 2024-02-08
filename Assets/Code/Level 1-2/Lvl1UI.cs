using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1UI : MonoBehaviour
{
    public static Lvl1UI Singleton;
    public TextMeshProUGUI scoreText;

    private float numPlanks;

    // Start is called before the first frame update
    void Start()
    {
        Singleton = this;

        scoreText.text = "0";
        numPlanks = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (numPlanks == 10)
        {
            scoreText.text = "win";
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
}
