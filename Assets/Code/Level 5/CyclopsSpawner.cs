using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclopsSpawner : MonoBehaviour
{
    /// Object to spawn
    public GameObject Cyclops;

    /// Seconds between spawn operations
    public float SpawnInterval = 3.0f;

    /// When the next enemy should be spawned
    public float nextSpawnTime = 0;

    // Reference to Atlas
    public Atlas atlas;

    // Range for random spawning
    public float SpawnRange = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        atlas = FindObjectOfType<Atlas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (/*!atlas.isDead &&*/ Time.time > nextSpawnTime)
        {
            // Calculate random spawn point away from Atlas
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Vector2 spawnPoint = (Vector2)atlas.transform.position + randomDirection * SpawnRange;

            // Instantiate a Cyclops at the calculated spawn point
            Instantiate(Cyclops, spawnPoint, Quaternion.identity);

            // Set the next spawn time by adding the SpawnInterval to the current time.
            nextSpawnTime = Time.time + SpawnInterval;
        }
    }
}