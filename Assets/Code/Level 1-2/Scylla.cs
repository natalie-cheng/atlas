using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scylla : MonoBehaviour
{
    // player position
    private Transform player;

    // scylla vars
    public float radius = 8; // range of vorax
    public float dmg = 10f;

    // scylla shot time tracker
    private float shotDelay = 2.5f;
    private float currentTime;
    // scylla shot
    public GameObject shotPrefab;

    // call start
    void Start()
    {
        // player and current time
        player = FindObjectOfType<AtlasLvl2>().transform;
        currentTime = Time.time - shotDelay;
    }

    // frame update
    void Update()
    {
        // if the player is within range, shoot shot
        if (WithinRange())
        {
            Shoot();
        }
    }

    // return whether the player is within the range of scylla
    private bool WithinRange()
    {
        // get the distance between scylla and the player
        float playerDist = Vector2.Distance(transform.position, player.position);
        // if it's less than the radius, it's within range
        if (playerDist < radius)
        {
            return true;
        }

        return false;
    }

    // shoot scylla shot
    private void Shoot()
    {
        // if enough time has passed
        if (Time.time - currentTime > shotDelay)
        {
            // shoot the shot and update
            GameObject shot = Instantiate(shotPrefab, transform.position, transform.rotation);
            currentTime = Time.time;
        }
    }

    // if it collides with anything
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // destroy object
        if (collision.collider.tag.Contains("BoatLvl2"))
        {
            Lvl2UI.changeHealth(dmg);
        }
    }
}
