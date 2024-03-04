using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScyllaShot : MonoBehaviour
{
    // set the time and lifespan of the shot
    private float currentTime;
    public float lifespan = 4;

    // shot vars
    private Rigidbody2D rb;
    public float shotSpeed = 4;
    public float dmg = 5f;

    // player position and direction
    private Transform player;
    private Vector3 playerDir;
    private float playerAngle;

    // call start
    private void Start()
    {
        // find the player
        player = FindObjectOfType<AtlasLvl2>().transform;
        // initialize shot rigidbody
        rb = GetComponent<Rigidbody2D>();

        // get the direction of the player
        playerDir = (player.position - transform.position);
        playerDir = Vector3.Normalize(playerDir);

        // set the velocity in the direction of the player
        // velocity is constant throughout shot life
        rb.velocity = playerDir * shotSpeed;

        // calculate the angle to the player
        playerAngle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;

        // rotate the shot by angle to face the player
        transform.rotation = Quaternion.AngleAxis(playerAngle, Vector3.forward);

        // set currentTime
        currentTime = Time.time;
    }

    // frame update
    private void Update()
    {
        // if lifespan time has passed, destroy object
        if (Time.time - currentTime > lifespan)
        {
            Destroy(gameObject);
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
        Destroy(gameObject);
    }
}
