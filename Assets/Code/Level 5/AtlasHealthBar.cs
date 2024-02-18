using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AtlasHealthBar : MonoBehaviour
{
    private TMP_Text healthDisplay;

    public Atlas_Level5 atlas;

    private void Start()
    {
        healthDisplay = GetComponentInChildren<TMP_Text>();
        // Access the RectTransform of the TextMeshPro object
        RectTransform textRectTransform = healthDisplay.rectTransform;

        // Modify the x and y coordinates of the TextMeshPro object's RectTransform
        textRectTransform.anchoredPosition = new Vector2(-600, 400); // Replace xValue and yValue with your desired coordinates
    }

    private void Update()
    {
        healthDisplay.text = "Health: " + Atlas_Level5.health;
    }
}
