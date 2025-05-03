using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerControles controls; // Generated class from the Input System
    public Animator animator; // Reference to the animator for shooting animations
    public GameObject bullet;
    public Transform bulletHole;
    public float force = 200;



    void Awake()
    {
        controls = new PlayerControles(); // Initialize the controls
        controls.Enable(); // Enable the controls

        // Subscribe to the shoot action (assuming the action is called "Shoot" under the "Land" action map)
        controls.Land.Shoot.performed += ctx => Fire();
    }

    void Fire()
{
    // Trigger the shoot animation
    animator.SetTrigger("shoot");
    
    // Instantiate the bullet at the bulletHole position
    GameObject go = Instantiate(bullet, bulletHole.position, bullet.transform.rotation);

    // Check if the player is facing right and apply force in the correct direction
    if (GetComponent<PlayerMovement>().isFacingRight)
        go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force); // Fire to the right
    else
        go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);  // Fire to the left

    // Play the shooting sound
    AudioManager.instance.Play("Fire");
}

    // Make sure to disable the controls when the object is destroyed or disabled
    private void OnDestroy()
    {
        controls.Disable();
    }
}
