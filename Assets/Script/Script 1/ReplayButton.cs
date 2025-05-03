using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour
{
    // This method is called when the Replay button is clicked
    public void ReplayLevel()
    {
        // Reload the current active scene (replay the level)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Optionally, reset the time scale in case the game was paused
        Time.timeScale = 1f;
    }
}
