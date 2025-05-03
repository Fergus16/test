using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvents1 : MonoBehaviour
{public Slider volumeSlider1;
    public AudioMixer mixer;
    
    private float value1;

    private void Start()
    {
        Time.timeScale = 1;

        // Initialize both sliders with the current mixer values
        mixer.GetFloat("volume1", out value1);
        volumeSlider1.value = value1;
   
    }

    // Set the volume for the first mixer input
    public void SetVolume1()
    {
        mixer.SetFloat("volume1", volumeSlider1.value);
    }

    
}
