//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Method - Handle collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If collides with the bird
            //bool didHitBird = collision.collider.GetComponent<FatBird>() != null;
        // Object type Fatbird 
        FatBird bird = collision.collider.GetComponent<FatBird>();

        if (bird != null)
        {
            Destroy(gameObject);
            return;
        }

        // Object type Enemy for collisions
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return;
        }

        // Collision from the top. 0 for first collision.
        if (collision.contacts[0].normal.y < - 0.5)
        {
            Destroy(gameObject);
        }

    }
}
