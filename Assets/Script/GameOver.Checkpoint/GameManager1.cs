using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line for UI elements like Button

public class GameManager1 : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the Pause Menu UI
    public Button resumeButton; // Reference to the Resume Button

    void Start()
    {
        // Initially hide the pause menu
        pauseMenuUI.SetActive(false);

        // Set the button to trigger the ResumeGame function
        resumeButton.onClick.AddListener(ResumeGame);
    }

    void Update()
    {
        // Pause the game when the player presses the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        // Hide the pause menu
        pauseMenuUI.SetActive(false);

        // Resume the game
        Time.timeScale = 1f;
    }

    void PauseGame()
    {
        // Show the pause menu
        pauseMenuUI.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;
    }
}

