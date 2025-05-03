using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons; // Array of level buttons
    public UIManager uIManager;

    public void ShowLevelMenu()
    {
        // Fetch the unlocked level for the current player
        string currentPlayer = uIManager.GetCurrentPlayer();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel" + currentPlayer, 1);

        Debug.Log("Current unlocked level for " + currentPlayer + ": " + unlockedLevel);

        // Disable all buttons first
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        // Enable buttons up to the unlocked level
        for (int i = 0; i < unlockedLevel && i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void OpenLevel(int LevelId)
    {
        // Ensure the level ID matches the actual scene name pattern (e.g., "Level1", "Level2", etc.)
        string levelName = "Level" + LevelId;

        // Load the scene corresponding to the level
        if (SceneManager.GetSceneByName(levelName) != null)
        {
            SceneManager.LoadScene(levelName);
        }
        else
        {
            Debug.LogWarning("Level " + levelName + " not found!");
        }
    }
}














































/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons; // Array of level buttons
    public InputField nameInputField; // Input field for player name
    public Text playerNameText; // Text UI to display player name and level
    public Button submitButton; // Button to submit the name

    private void Awake()
    {
        // Check if a player name is already saved in PlayerPrefs
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            string savedName = PlayerPrefs.GetString("PlayerName");
            int savedLevel = PlayerPrefs.GetInt("PlayerLevel", 1);

            playerNameText.text = $"Name: {savedName}\nLevel: {savedLevel}";
        }
        else
        {
            playerNameText.text = "Enter your name!";
        }

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Disable all buttons first
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        // Enable buttons up to the unlocked level
        for (int i = 0; i < unlockedLevel && i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }

        // Add listener for the submit button
        submitButton.onClick.AddListener(SubmitName);

        // Update player progress display if already on a level
        UpdateLevelDisplay();
    }

    public void SubmitName()
    {
        string playerName = nameInputField.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            // Save player name and level in PlayerPrefs
            PlayerPrefs.SetString("PlayerName", playerName);
            PlayerPrefs.SetInt("PlayerLevel", 1); // Set initial level as 1
            PlayerPrefs.Save();
            playerNameText.text = $"Name: {playerName}\nLevel: 1";
        }
        else
        {
            playerNameText.text = "Please enter a valid name!";
        }
    }

    public void OpenLevel(int LevelId)
    {
        string levelName = "Level" + LevelId;

        // Save the current level to PlayerPrefs
        PlayerPrefs.SetInt("PlayerLevel", LevelId);
        PlayerPrefs.Save();

        // Load the specified level
        SceneManager.LoadScene(levelName);
    }

    private void UpdateLevelDisplay()
    {
        if (PlayerPrefs.HasKey("PlayerName") && PlayerPrefs.HasKey("PlayerLevel"))
        {
            string savedName = PlayerPrefs.GetString("PlayerName");
            int savedLevel = PlayerPrefs.GetInt("PlayerLevel");

            // Update the displayed name and level
            playerNameText.text = $"Name: {savedName}\nLevel: {savedLevel}";
        }
    }

    private void OnEnable()
    {
        // Subscribe to scene change events to update the level display
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from scene change events
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Update the displayed level when a new scene is loaded
        UpdateLevelDisplay();
    }
}
*/