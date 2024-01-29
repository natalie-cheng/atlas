using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    // frame update
    private void Update()
    {
        // if the player is "using" and colliding with the plank
        if (Input.GetAxis("Attack") == 1)
        {
            if (IsColliding())
            {
                Lvl1UI.addPlank();
                Destroy(gameObject);
            }
        }
    }

    // checks if this object is colliding with another
    private bool IsColliding()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, transform.localScale, 0f);

        return collider != null && collider.gameObject != gameObject;
    }
}
