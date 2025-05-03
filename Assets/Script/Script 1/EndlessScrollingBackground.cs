using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f;  // Speed of the scrolling background
    public float backgroundWidth = 10f; // Width of the background image or sprite
    public GameObject backgroundPrefab; // Optional: Background prefab to instantiate

    private Vector3 startPosition;

    private void Start()
    {
        // Store the starting position of the background
        startPosition = transform.position;
    }

    private void Update()
    {
        // Move the background to create a scrolling effect
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // Check if the background has moved out of view
        if (transform.position.x <= startPosition.x - backgroundWidth)
        {
            // Reset the position to create a looping effect
            transform.position = startPosition;
        }
    }
}
