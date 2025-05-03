using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq.Expressions;
using UnityEngine.SceneManagement;
using System;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public GameObject playerListContainer;
    public GameObject playerButtonPrefab;
    public GameObject oldPlayersPanel;
    public int playerCount;
    public string currentPlayer;
    public UIManager uIManager;
    public int currentStageLevel;

    [SerializeField] string[] players = new string[20];

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        playerCount = PlayerPrefs.GetInt("playerCount", 0);
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == "Menu")
        {
            GameObject canvas = GameObject.Find("Canvas").gameObject;
            playerListContainer = canvas.transform.GetChild(6).GetChild(4).GetChild(0).GetChild(0).gameObject;
            oldPlayersPanel = canvas.transform.GetChild(6).gameObject;
            uIManager = canvas.GetComponent<UIManager>();
            ShowPlayerList();
        }
    }

    public void SetPlayerCount()
    {
        playerCount++;
        PlayerPrefs.SetInt("playerCount", playerCount);
    }

    private void OnEnable()
    {
        ShowPlayerList();
    }

    public void CreatePlayer(string playerName)
    {
        Debug.Log("SavePlayerName called: " + playerName);
        PlayerPrefs.SetString("playerName" + playerCount, playerName);
        PlayerPrefs.SetInt("UnlockedLevel" + playerName, 1);

        // ➡️ ADDITION STARTS HERE: Make sure panels are not repeated
        List<int> usedPanels = new List<int>();
        for (int i = 0; i <= 20; i++)
        {
            string name = PlayerPrefs.GetString("playerName" + i, string.Empty);
            if (!string.IsNullOrEmpty(name))
            {
                int panelIndex = PlayerPrefs.GetInt("UIPanel_" + name, -1);
                if (panelIndex != -1)
                {
                    usedPanels.Add(panelIndex);
                }
            }
        }

        List<int> availablePanels = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            if (!usedPanels.Contains(i))
            {
                availablePanels.Add(i);
            }
        }

        int randomPanelIndex;
        if (availablePanels.Count > 0)
        {
            randomPanelIndex = availablePanels[UnityEngine.Random.Range(0, availablePanels.Count)];
        }
        else
        {
            randomPanelIndex = UnityEngine.Random.Range(0, 3);
            Debug.LogWarning("All panels are already used, reusing panel randomly.");
        }

        PlayerPrefs.SetInt("UIPanel_" + playerName, randomPanelIndex);
        // ➡️ ADDITION ENDS HERE

        SetPlayerCount();
    }

    public void ShowPlayerList()
    {
        foreach (Transform child in playerListContainer.transform)
        {
            Destroy(child.gameObject);
        }
        Array.Clear(players, 0, players.Length);

        for (int i = 0; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("playerName" + i, string.Empty) != string.Empty)
            {
                players[i] = PlayerPrefs.GetString("playerName" + i);
                int playerCurrentLevel = PlayerPrefs.GetInt("UnlockedLevel" + players[i]);

                try
                {
                    uIManager.playerLevels.Add(players[i], PlayerPrefs.GetInt("completedLevel", 1));
                }
                catch (System.Exception)
                {
                    Debug.Log("Already Added");
                }

                GameObject buttonObj = Instantiate(playerButtonPrefab, playerListContainer.transform);
                buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = $"{players[i]} - Level {playerCurrentLevel}";

                string capturedName = players[i];
                buttonObj.GetComponent<Button>().onClick.AddListener(() => {
                    oldPlayersPanel.SetActive(false);
                    PlayerPrefs.SetString("CurrentPlayer", capturedName);
                    uIManager.PlayGame(capturedName);
                });
            }
        }
    }

    public void SavePlayerUnlockedLevel(int newVal)
    {
        PlayerPrefs.SetInt("UnlockedLevel" + currentPlayer, newVal);
    }
}