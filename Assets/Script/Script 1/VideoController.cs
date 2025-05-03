using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video; // Import the Video namespace

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Assign your VideoPlayer in the Inspector
    public Button playButton;      // Assign your Play button
    public Button resetButton;     // Assign your Reset button

    void Start()
    {
        // Add button listeners
        playButton.onClick.AddListener(PlayVideo);
        resetButton.onClick.AddListener(ResetVideo);
    }

    void PlayVideo()
    {
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
    }

    void ResetVideo()
    {
        videoPlayer.Stop();
        videoPlayer.time = 0; // Reset to the beginning
    }
}
