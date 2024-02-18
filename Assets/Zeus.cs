using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;


public class Zeus : MonoBehaviour
{
    public float trackTime;
    public bool goUp;
    public float speed = 0.1f;
    public GameObject ProjectilePrefab;
    public Rigidbody2D rigidBody;
    public float projectileVel = 5;
    public float shootingInterval = 500;
    public Transform boat;
    public float projMass = 0.0001f;

    private Vector2 OffsetToBoat => boat.position - transform.position;
    private Vector2 HeadingToBoat => OffsetToBoat.normalized;

    // Start is called before the first frame update
    void Start()
    {
        trackTime = 0;
        goUp = true;
    }

    // Update is called once per frame
    void Update()
    {

        trackTime += 1;
        if (trackTime % shootingInterval == 0)
        {
            FireProjectile();
        }
        if (transform.position.y >= 20)
        {
            goUp = false;
        } else if (transform.position.y <= -20)
        {
            goUp = true;
        }
        if (goUp)
        {
            Vector3 newPosition = transform.position + new Vector3(0f, speed, 0f);
            transform.position = newPosition;
        } else
        {
            Vector3 newPosition = transform.position - new Vector3(0f, speed, 0f);
            transform.position = newPosition;
        }
    }

    private void FireProjectile()
    {
        //Vector3 temp = new Vector3(rigidBody.position.x, rigidBody.position.y, 0);
        //GameObject proj = Instantiate(ProjectilePrefab, temp + transform.right, Quaternion.identity);

        //Rigidbody2D projRigidBody = proj.GetComponent<Rigidbody2D>();
        //projRigidBody.velocity = projectileVel * transform.right;

        var new_proj = Instantiate(ProjectilePrefab, transform.localPosition, Quaternion.identity);
        var proj_pos = new Vector3(HeadingToBoat.x, HeadingToBoat.y, transform.localPosition.z);
        new_proj.transform.localPosition = transform.localPosition + proj_pos;
        new_proj.GetComponent<Rigidbody2D>().mass = projMass;
        new_proj.GetComponent<Rigidbody2D>().velocity = projectileVel * HeadingToBoat;

    }

    void FixedUpdate()
    {
        var offsetToBoat = OffsetToBoat;
        var distanceToPlayer = offsetToBoat.magnitude;

    }
}
