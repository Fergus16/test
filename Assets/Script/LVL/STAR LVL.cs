using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class STARLVL : MonoBehaviour
{
    public int totalCoins; // Total number of coins in the level
    private int collectedCoins; // Coins the player has collected

    public Image[] stars; // UI Images for the stars
    public Sprite filledStar; // Filled star sprite when awarded
    public GameObject levelCompleteUI; // UI to show when the level is completed
    public Text coinText; // UI Text to show the number of collected coins

    public GameObject[] coins; // Array to store all the coin GameObjects in the level

    void Start()
    {
        // Initialize the number of collected coins and update the UI
        collectedCoins = 0;
        totalCoins = coins.Length; // Set total coins based on the number of coin objects in the level
        UpdateCoinText();
        levelCompleteUI.SetActive(false); // Hide the level complete UI at start
    }

    void UpdateCoinText()
    {
        coinText.text = collectedCoins.ToString() + "/" + totalCoins.ToString(); // Update the coin count in UI
    }

    public void CollectCoin(GameObject coin)
    {
        collectedCoins++;
        UpdateCoinText();
        Destroy(coin); // Destroy the coin after collection

        // Check if all coins are collected to complete the level
        if (collectedCoins == totalCoins)
        {
            LevelCompleted();
        }
    }

    // Show the level complete UI and calculate the star rating
    void LevelCompleted()
    {
        levelCompleteUI.SetActive(true); // Show the level complete UI
        CalculateStarRating(); // Calculate and display the stars based on coin collection
    }

    // Determine how many stars to award based on the percentage of coins collected
    void CalculateStarRating()
    {
        float percentageCollected = (float)collectedCoins / totalCoins;

        if (percentageCollected == 1f)
        {
            // Award 3 stars
            AwardStars(3);
        }
        else if (percentageCollected >= 0.66f)
        {
            // Award 2 stars
            AwardStars(2);
        }
        else if (percentageCollected >= 0.33f)
        {
            // Award 1 star
            AwardStars(1);
        }
        else
        {
            // No stars awarded
            AwardStars(0);
        }
    }

    // Set the appropriate number of stars in the UI
    void AwardStars(int numberOfStars)
    {
        for (int i = 0; i < numberOfStars; i++)
        {
            stars[i].sprite = filledStar; // Set the star to the filled star sprite
        }
    }

    // Replay the current level
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Go to the next level
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Trigger collection when the player touches the coin
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            CollectCoin(other.gameObject); // Call CollectCoin when the player collides with a coin
        }
    }
}
