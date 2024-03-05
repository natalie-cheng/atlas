using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private float moveInc = 0.1f;
    private float moveHit = 5f;

    public static float xPos;
    public static AudioManager audiomanager;

    // Start is called before the first frame update
    void Start()
    {
        xPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // this is natalie i just changed the input so it matches the other levels
        // To be done: use GetKeyDown to push players position up and down, but have the player gravitate to center
        if ((Input.GetKey("up") || Input.GetKey(KeyCode.W)) && transform.position.y < 19)
        {
            Vector3 newPosition = transform.position + new Vector3(0f, moveInc, 0f);
            transform.position = newPosition;
        }
        else if ((Input.GetKey("down") || Input.GetKey(KeyCode.S)) && transform.position.y > -19)
        {
            Vector3 newPosition = transform.position - new Vector3(0f, moveInc, 0f);
            transform.position = newPosition;
        }
        
        if (Input.GetAxis("Vertical")==1 && transform.position.y < 19)
        {
            Vector3 newPosition = transform.position + new Vector3(0f, moveInc, 0f);
            transform.position = newPosition;
        } else if (Input.GetAxis("Vertical")==-1 && transform.position.y > -19)
        {
            Vector3 newPosition = transform.position - new Vector3(0f, moveInc, 0f);
            transform.position = newPosition;
        }

        xPos = transform.position.x;
        
    }

    public void GoLeft()
    {
        //print("HELLP");
        Vector3 newPosition = transform.position - new Vector3(moveHit, 0f, 0f);
        transform.position = newPosition;
        xPos = transform.position.x;

    }
    public void GoRight()
    {
        //print("HELLP");

        Vector3 newPosition = transform.position + new Vector3(moveHit, 0f, 0f);
        transform.position = newPosition;
        xPos = transform.position.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if make contact with Boat, move boat left
        if (collision.collider.gameObject.GetComponent<Rock>())
        {
            // audiomanager.playHitRock();
            //AudioManager.audiomanager.rockSound();
        }
    }
}
