using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    public float health = 10f;
    public GameObject atlas; 
    private Dictionary<GameObject, Vector3> birdStartingPositions = new Dictionary<GameObject, Vector3>();
    private List<GameObject> birds = new List<GameObject>();
    public float delayBetweenBirds = 2f; 
    public float speed = 3f;
    private float birdDmg = 25f;

    void Start()
    {
        GameObject[] birdsArray = GameObject.FindGameObjectsWithTag("Bird");
        foreach (GameObject bird in birdsArray)
        {
            birds.Add(bird);
            birdStartingPositions[bird] = bird.transform.position;
        }

        StartCoroutine(SendBirdsTowardsAtlas());
    }

    private void Update()
    {
        if (health == 0)
        {
            Die();
        }

      
        RemoveDestroyedBirds();
    }

    IEnumerator SendBirdsTowardsAtlas()
    {
        while (true) 
        {
            for (int i = 0; i < birds.Count; i++)
            {
                if (birds[i] != null) 
                {
                    
                    StartCoroutine(MoveBirdTowardsAtlas(birds[i], i));
                }
                
                yield return new WaitForSeconds(delayBetweenBirds);
            }

            
            yield return new WaitForSeconds(delayBetweenBirds * birds.Count);
        }
    }

    IEnumerator MoveBirdTowardsAtlas(GameObject bird, int index)
    {
        Vector3 direction = (atlas.transform.position - bird.transform.position).normalized;
        Vector3 startingPosition = birdStartingPositions[bird];

        while (bird != null && !bird.GetComponent<Renderer>().isVisible)
        {
            // Initial wait until the bird is visible if starting off-screen
            yield return null;
        }

        while (bird != null) // Keep this loop running to continue the behavior
        {
            // Move bird towards Atlas
            bird.transform.position += direction * speed * Time.deltaTime;
            

            // Check if the bird has moved off-screen
            if (!bird.GetComponent<Renderer>().isVisible)
            {
                // Reset bird position to its starting position
                bird.transform.position = birdStartingPositions[bird]; 
                // Break this iteration of the loop to restart the movement from the beginning
                break;
            }
            yield return null; // Wait for the next frame
        }

        if (bird != null) // Ensure the bird has not been destroyed before restarting
        {
            // After resetting, restart the coroutine for this bird to repeat the process
            StartCoroutine(MoveBirdTowardsAtlas(bird, index));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collide = collision.collider;

        Atlas_Level3 atlas = FindObjectOfType<Atlas_Level3>();
        if (atlas != null)
        {

            if (collide.gameObject.name == atlas.name)
            {
                Lvl3UI.changeHealth(birdDmg);
            }
            else
            {
                health -= 5f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Atlas_Level3 atlas = FindObjectOfType<Atlas_Level3>();
        if (atlas != null)
        {

            if (collision.gameObject.name == atlas.name)
            {
                Lvl3UI.changeHealth(birdDmg);
                atlas.spriteRenderer.color = Color.red;
            }
            else
            {
                health -= 5f;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Atlas_Level3 atlas = FindObjectOfType<Atlas_Level3>();
        atlas.spriteRenderer.color = Color.white;

    }

    private void RemoveDestroyedBirds()
    {
        for (int i = birds.Count - 1; i >= 0; i--)
        {
            if (birds[i] == null)
            {
                birdStartingPositions.Remove(birds[i]);
                birds.RemoveAt(i);
            }
        }

    }

    private void Die()
    {
        Lvl3UI.numBirds--;
        Destroy(gameObject);
    }
}
