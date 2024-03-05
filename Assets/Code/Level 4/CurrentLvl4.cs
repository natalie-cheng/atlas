using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Current : MonoBehaviour
{
    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
    
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position - new Vector3(speed * Time.deltaTime, 0f, 0f);
        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if make contact with Boat, move boat left
        if (collision.collider.gameObject.GetComponent<Boat>())
        {
            collision.collider.gameObject.GetComponent<Boat>().GoRight();
            Destroy(gameObject);
        }
    }
}
