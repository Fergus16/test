using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver = false; // Game over flag
    public static bool isAbout = false;   // About screen flag
    public GameObject gameOverScreen;    // Game over UI screen
    public GameObject gameAboutScreen;   // About UI screen
    public GameObject pauseMenuScreen;   // Pause menu UI screen

    public static Vector2 lastCheckPointPos = new Vector2(-16, -2); // Last checkpoint position
    public static int numberOfCoins = 0;                            // Coins collected
    public TextMeshProUGUI coinsText;                               // UI for coin count

    private void Awake()
    {
        // Initialize game state
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;
        isAbout = false;

        // Place the player at the last checkpoint position
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }

    void Update()
    {
        // Update coin count UI
        coinsText.text = numberOfCoins.ToString();

        // Display About panel
        if (isAbout)
        {
            gameAboutScreen.SetActive(true);
            Time.timeScale = 0f; // Pause game
        }

        // Display Game Over screen
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void CloseAboutPanel()
    {
        isAbout = false;
        gameAboutScreen.SetActive(false);
        Time.timeScale = 1f;
    }
    
    // Method to display the About panel when the button is clicked
    public void ShowAboutPanel()
    {
        isAbout = true;
        gameAboutScreen.SetActive(true);  // Show the About panel
        Time.timeScale = 0f;              // Pause the game
    }
}
/*using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public static bool isGameOver;
    public static bool isAbout;
    public GameObject gameOverScreen;
    public GameObject gameAboutScreen;
    public GameObject pauseMenuScreen;

    // Tracks the player's last checkpoint position and coins collected
    public static Vector2 lastCheckPointPos = new Vector2(-16, -2);
    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

    private void Awake()
    {
        // Initialize variables
        isAbout = false;
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the coin count UI
        coinsText.text = numberOfCoins.ToString();

        // Check if the About panel should be displayed
        if (isAbout)
        {
            gameAboutScreen.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }

        // Check if the Game Over screen should be displayed
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    // Method for replaying the current level
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Method to pause the game
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    // Method to resume the game
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    // Method to display the About panel when the button is clicked
    public void ShowAboutPanel()
    {
        isAbout = true;
        gameAboutScreen.SetActive(true);  // Show the About panel
        Time.timeScale = 0f;              // Pause the game
    }

    // Method to close the About panel and resume the game
    public void CloseAboutPanel()
    {
        isAbout = false;
        gameAboutScreen.SetActive(false); // Hide the About panel
        Time.timeScale = 1f;              // Resume the game
    }
}
*/

/*using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver = false; // Game over flag
    public static bool isAbout = false;   // About screen flag
    public GameObject gameOverScreen;    // Game over UI screen
    public GameObject gameAboutScreen;   // About UI screen
    public GameObject pauseMenuScreen;   // Pause menu UI screen

    public static Vector2 lastCheckPointPos = new Vector2(-16, -2); // Last checkpoint position
    public static int numberOfCoins = 0;                            // Coins collected
    public TextMeshProUGUI coinsText;                               // UI for coin count

    private void Awake()
    {
        // Initialize game state
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;
        isAbout = false;

        // Place the player at the last checkpoint position
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }

    void Update()
    {
        // Update coin count UI
        coinsText.text = numberOfCoins.ToString();

        // Display About panel
        if (isAbout)
        {
            gameAboutScreen.SetActive(true);
            Time.timeScale = 0f; // Pause game
        }

        // Display Game Over screen
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void CloseAboutPanel()
    {
        isAbout = false;
        gameAboutScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}

*/

/*using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public static bool isGameOver;
    public static bool isAbout;
    public GameObject gameOverScreen;
    public GameObject gameAboutScreen;
    public GameObject pauseMenuScreen;

    // Tracks the player's last checkpoint position and coins collected
    public static Vector2 lastCheckPointPos = new Vector2(-16, -2);
    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

    private void Awake()
    {
        // Initialize variables
        isAbout = false;
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the coin count UI
        coinsText.text = numberOfCoins.ToString();

        // Check if the About panel should be displayed
        if (isAbout)
        {
            gameAboutScreen.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }

        // Check if the Game Over screen should be displayed
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    // Method for replaying the current level
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Method to pause the game
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    // Method to resume the game
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    // Method to display the About panel when the button is clicked
    public void ShowAboutPanel()
    {
        isAbout = true;
        gameAboutScreen.SetActive(true);  // Show the About panel
        Time.timeScale = 0f;              // Pause the game
    }

    // Method to close the About panel and resume the game
    public void CloseAboutPanel()
    {
        isAbout = false;
        gameAboutScreen.SetActive(false); // Hide the About panel
        Time.timeScale = 1f;              // Resume the game
    }
}
*/