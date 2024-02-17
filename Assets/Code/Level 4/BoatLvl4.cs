using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private float moveInc = 0.1f;
    private float moveHit = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // this is natalie i just changed the input so it matches the other levels
        // To be done: use GetKeyDown to push players position up and down, but have the player gravitate to center
        if ((Input.GetKey("up") || Input.GetKey(KeyCode.W)) && transform.position.y < 15)
        {
            Vector3 newPosition = transform.position + new Vector3(0f, moveInc, 0f);
            transform.position = newPosition;
        }
        else if ((Input.GetKey("down") || Input.GetKey(KeyCode.S)) && transform.position.y > -15)
        {
            Vector3 newPosition = transform.position - new Vector3(0f, moveInc, 0f);
            transform.position = newPosition;
        }
        
        if (Input.GetAxis("Vertical")==1 && transform.position.y < 15)
        {
            Vector3 newPosition = transform.position + new Vector3(0f, moveInc, 0f);
            transform.position = newPosition;
        } else if (Input.GetAxis("Vertical")==-1 && transform.position.y > -15)
        {
            Vector3 newPosition = transform.position - new Vector3(0f, moveInc, 0f);
            transform.position = newPosition;
        }
            
        
    }

    public void GoLeft()
    {
        print("HELLP");
        Vector3 newPosition = transform.position - new Vector3(moveHit, 0f, 0f);
        transform.position = newPosition;
         
    }
    public void GoRight()
    {
        print("HELLP");

        Vector3 newPosition = transform.position + new Vector3(moveHit, 0f, 0f);
        transform.position = newPosition;

    }
}
