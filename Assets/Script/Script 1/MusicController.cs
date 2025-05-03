using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource backgroundMusic; // Reference to the audio source playing the background music
    public Button musicButton; // Reference to the UI button

    private bool isPlaying = true; // To keep track of the music state

    void Start()
    {
        // Ensure the button has an onClick event listener
        if (musicButton != null)
        {
            musicButton.onClick.AddListener(ToggleMusic);
        }

        // Ensure the background music is playing at the start
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
            isPlaying = true;
        }
    }

    void ToggleMusic()
    {
        if (isPlaying)
        {
            backgroundMusic.Pause();
        }
        else
        {
            backgroundMusic.Play();
        }
        isPlaying = !isPlaying;
    }
}
