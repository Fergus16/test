using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    public string currentPlayerName; // Set this when the player starts the game

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnlockNewLevel();
            // portal 2D BOX INTERFACE
            SceneController.instance.NextLevel();
            // Song konohay ahh
            AudioManager.instance.Play("portal");
        }
    }

    void UnlockNewLevel()
    {
        int playerCurrentLevel = PlayerPrefs.GetInt("UnlockedLevel" + SaveManager.instance.currentPlayer);
        
        if (SceneManager.GetActiveScene().buildIndex - 1 >= PlayerPrefs.GetInt("ReachedIndex" + SaveManager.instance.currentPlayer))
        {
            // Unlock next level globally
            PlayerPrefs.SetInt("ReachedIndex" + SaveManager.instance.currentPlayer, SceneManager.GetActiveScene().buildIndex);
            SaveManager.instance.SavePlayerUnlockedLevel(playerCurrentLevel + 1);
            PlayerPrefs.Save();

            // Unlock level for the current player
            UIManager uiManager = FindObjectOfType<UIManager>();
            if (uiManager != null && !string.IsNullOrEmpty(currentPlayerName))
            {
                uiManager.UnlockLevel(currentPlayerName);
            }
        }
    }

}