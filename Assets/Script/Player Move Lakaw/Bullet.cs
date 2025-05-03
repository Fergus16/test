using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // ||--Destroy enemy and the bullet on collision --|| 
        if (collision.tag == "Enemy2")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        // ||--Destroy the bullet if it hits the ground layer:--|| 
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            Destroy(gameObject);
        }
    }
}
