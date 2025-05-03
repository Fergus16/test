

using UnityEngine;

public class DisplayUIOnHit : MonoBehaviour
{
    public GameObject uiPanel;// The UI panel to display when the player hits the GameObject
     public float displayTime = 2f; // How long the UI will stay visible after the player hits

    private void Start()
    {
        // Initially hide the UI panel
        uiPanel.SetActive(false);
    }

    // Called when the player enters the trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player collided
        {
            // Show the UI panel
            uiPanel.SetActive(true);

             Invoke("HideUIPanel", displayTime);
        }
    }

    // Called when the player exits the trigger collider
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player exits
        {
            // Hide the UI panel
            uiPanel.SetActive(false);
        }
    }
}
