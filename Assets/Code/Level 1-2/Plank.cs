using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    private bool colliding;

    // call start
    private void Start()
    {
        colliding = false;
    }

    // frame update
    private void Update()
    {
        // if the player is "using" and colliding with the plank
        if (Input.GetAxis("Attack") == 1)
        {
            if (colliding)
            {
                Lvl1UI.addPlank();
                AtlasLvl1.woodSfx = true;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            colliding = true;
        }
    }
}
