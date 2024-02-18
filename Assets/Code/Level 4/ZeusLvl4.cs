using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeus : MonoBehaviour
{
    private bool goUp;
    private float speed = 0.1f;
    public GameObject ProjectilePrefab;
    public Rigidbody2D rigidBody;
    private float projectileVel = 10;
    public Transform boat;
    private float projMass = 0.0001f;
    private float lastFireTime;
    private const float fireInterval = 2f;

    private Vector2 OffsetToBoat => boat.position - transform.position;
    private Vector2 HeadingToBoat => OffsetToBoat.normalized;

    // Start is called before the first frame update
    void Start()
    {
        goUp = true;
        lastFireTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time - lastFireTime >= fireInterval)
        {
            FireProjectile();
            lastFireTime = Time.time;
        }

        if (transform.position.y >= 20)
        {
            goUp = false;
        }
        else if (transform.position.y <= -20)
        {
            goUp = true;
        }

        if (goUp)
        {
            Vector3 newPosition = transform.position + new Vector3(0f, speed * Time.deltaTime, 0f);
            transform.position = newPosition;
        }
        else
        {
            Vector3 newPosition = transform.position - new Vector3(0f, speed * Time.deltaTime, 0f);
            transform.position = newPosition;
        }
    }

    private void FireProjectile()
    {
        var new_proj = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
        new_proj.GetComponent<Rigidbody2D>().mass = projMass;
        new_proj.GetComponent<Rigidbody2D>().velocity = projectileVel * HeadingToBoat;
    }

    void FixedUpdate()
    {
        var offsetToBoat = OffsetToBoat;
        var distanceToPlayer = offsetToBoat.magnitude;
    }
}
