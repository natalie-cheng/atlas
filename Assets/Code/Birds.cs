using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{
    public float health = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.health == 0)
        {
            Die();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collide = collision.collider;

        Atlas_Level3 atlas = FindObjectOfType<Atlas_Level3>();

        if (collide.gameObject.name == atlas.name)
        {
            atlas.health -= 100;
        }
        else
        {
            this.health -= 5f;
        }

    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
