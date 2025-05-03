using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioSource backgroundMusicSource;  // Reference to the background music AudioSource
    public AudioSource alternativeMusicSource; // Reference to the alternative music AudioSource
    public Button toggleButton;                // Reference to the UI Button

    private bool isBackgroundMusicPlaying = true;

    void Start()
    {
        // Ensure the button calls the ToggleMusic method when clicked
        toggleButton.onClick.AddListener(ToggleMusic);
        
        // Ensure that the alternative music is stopped initially
        alternativeMusicSource.Stop();
    }

    // Method to toggle the music
    public void ToggleMusic()
    {
        if (isBackgroundMusicPlaying)
        {
            backgroundMusicSource.Stop();
            alternativeMusicSource.Play();
        }
        else
        {
            alternativeMusicSource.Stop();
            backgroundMusicSource.Play();
        }

        isBackgroundMusicPlaying = !isBackgroundMusicPlaying;
    }
}
