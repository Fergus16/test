using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    // UI Panels
    public GameObject newPlayerPanel;
    public GameObject enterNamePanel;
    public GameObject oldPlayersPanel;
    public GameObject gameStartPanel;

    // Input Field for entering player name
    public InputField playerNameInput;

    // Old Players List
    public GameObject playerListContainer;
    public GameObject playerButtonPrefab;

    // Store player levels
    public Dictionary<string, int> playerLevels = new Dictionary<string, int>();
    private string currentPlayer;


    public LevelMenu levelMenu;
    void Start()
    {
        ShowNewPlayerPanel();
    }

    // Show "New Player?" Panel
    public void ShowNewPlayerPanel()
    {
        newPlayerPanel.SetActive(true);
        enterNamePanel.SetActive(false);
        oldPlayersPanel.SetActive(false);
        gameStartPanel.SetActive(false);
    }

    // Show "Enter your name" Panel
    public void ShowEnterNamePanel()
    {
        newPlayerPanel.SetActive(false);
        enterNamePanel.SetActive(true);
        oldPlayersPanel.SetActive(false);
    }

    // Show "List of Old Players" Panel
    public void ShowOldPlayersPanel()
    {
        newPlayerPanel.SetActive(false);
        enterNamePanel.SetActive(false);
        oldPlayersPanel.SetActive(true);

        // Populate the player list
        PopulatePlayerList();
    }

    // Add a new player and initialize their level
    public void AddNewPlayer()
    {
        string playerName = playerNameInput.text;
        SaveManager.instance.CreatePlayer(playerName);

        
        if (!string.IsNullOrEmpty(playerName))
        {
            if (!playerLevels.ContainsKey(playerName))
            {
                // Initialize new player's level
                playerLevels[playerName] = 1;
                PlayerPrefs.SetInt(playerName, 1); // Save level
                PlayerPrefs.Save();
            }

            playerNameInput.text = ""; // Clear input field
            //ShowOldPlayersPanel();
        }
        else
        {
            Debug.LogWarning("Player name cannot be empty!");
        }

        SaveManager.instance.ShowPlayerList();
    }

    // Unlock level for the current player
    public void UnlockLevel(string playerName)
    {
        if (!string.IsNullOrEmpty(playerName))
        {
            // Increment the player's level by 1
            int currentLevel = PlayerPrefs.GetInt(playerName, 1);
            PlayerPrefs.SetInt(playerName, currentLevel + 1);
            PlayerPrefs.Save();

            // Update level in memory
            if (playerLevels.ContainsKey(playerName))
            {
                playerLevels[playerName] = currentLevel + 1;
            }

            Debug.Log($"Player {playerName} unlocked Level {currentLevel + 1}");
        }
    }

    
    // Populate the old players list dynamically
    public void PopulatePlayerList()
    {
        Debug.Log("PopulatePlayerList");
        

        // Clear existing buttons
        foreach (Transform child in playerListContainer.transform)
        {
            Destroy(child.gameObject);
        }

        //get list of players
        string[] players = new string[10];

        for(int i = 0; i <=10; i++) {
            if(PlayerPrefs.GetString("playerName" + i) != "") {
                players[i] = PlayerPrefs.GetString("playerName" + i); 
                GameObject buttonObj = Instantiate(playerButtonPrefab, playerListContainer.transform);
                buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = $"{players[i]} - Level {players[i]}";
            } 
        }

       
        
        // Add buttons for each player
        foreach (var player in playerLevels)
        {
            GameObject buttonObj = Instantiate(playerButtonPrefab, playerListContainer.transform);
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = $"{player.Key} - Level {player.Value}";
            buttonObj.GetComponent<Button>().onClick.AddListener(() => {
                oldPlayersPanel.SetActive(false);
                PlayGame(player.Key);
                });
        }
    }

    // Start game for the selected player
    public void PlayGame(string playerName)
    {
        currentPlayer = playerName;
        SaveManager.instance.currentPlayer = playerName;
        Debug.Log($"Starting game for: {playerName}");

        // Load the level from PlayerPrefs
        int playerLevel = PlayerPrefs.GetInt(playerName, 1);
        Debug.Log($"Loading Level: {playerLevel}");

        // Display game start panel
        gameStartPanel.SetActive(true);

        levelMenu.ShowLevelMenu();
    }

    // Save level progress when the player finishes
    public void SaveLevelProgress(int completedLevel)
    {
        if (!string.IsNullOrEmpty(currentPlayer))
        {
            int highestLevel = PlayerPrefs.GetInt(currentPlayer, 1);

            // Update only if the completed level is greater
            if (completedLevel > highestLevel)
            {
                PlayerPrefs.SetInt(currentPlayer, completedLevel);
                playerLevels[currentPlayer] = completedLevel; // Update in-memory dictionary
                PlayerPrefs.Save();
            }
        }
    }

    // Exit game
    public void ExitGame()
    {
        Debug.Log("Exiting game.");
        Application.Quit();
    }

    public String GetCurrentPlayer() 
    {
        return currentPlayer;
    }
}
