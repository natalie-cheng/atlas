using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public float moveInc = 0.25f;
    public float health = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // To be done: use GetKeyDown to push players position up and down, but have the player gravitate to center
        if (Input.GetKey(KeyCode.W) && transform.position.y < 15)
        {
            Vector3 newPosition = transform.position + new Vector3(0f, moveInc, 0f);
            transform.position = newPosition;
        } else if (Input.GetKey(KeyCode.S) && transform.position.y > -15)
        {
            Vector3 newPosition = transform.position - new Vector3(0f, moveInc, 0f);
            transform.position = newPosition;
        }
            
        
    }

    public void MinusHealth()
    {
        if (health <= 1)
        {
            Application.Quit();
        } else
        {
        this.health -= 1; 

        }
        
    }
}
