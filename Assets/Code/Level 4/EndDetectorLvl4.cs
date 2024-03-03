using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDetector : MonoBehaviour
{
    private float speed = 5f;
    public static float xPos;

    // Start is called before the first frame update
    void Start()
    {
        xPos = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position - new Vector3(speed * Time.deltaTime, 0f, 0f);
        transform.position = newPosition;
        xPos = transform.position.x;

    }
}
