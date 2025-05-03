using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public GameObject uiPanel;  // The UI Panel to display
    private bool isPaused = false;  // Tracks whether the game is paused

    void Start()
    {
        uiPanel.SetActive(false); // Initially hide the UI panel
    }

    void Update()
    {
        // Check if the player presses the 'P' key to toggle the UI
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                UnpauseGame();
            }
            else
            {
                DisplayUI();
            }
        }
    }

    // Display the UI and pause the game
    public void DisplayUI()
    {
        uiPanel.SetActive(true);  // Show the UI panel
        Time.timeScale = 0f;  // Pause the game
        isPaused = true;
    }

    // Hide the UI and unpause the game
    public void UnpauseGame()
    {
        uiPanel.SetActive(false);  // Hide the UI panel
        Time.timeScale = 1f;  // Resume the game
        isPaused = false;
    }
}
