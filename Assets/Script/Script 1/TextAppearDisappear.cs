using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;  // Use TMPro if you are using TextMeshPro

public class TextAppearDisappear : MonoBehaviour
{
    public Text textToToggle; 
    public Text textToToggle2;  // Drag your Text component here
    public float appearDuration = 2f;  // Time in seconds the text stays visible
    public float disappearDuration = 2f;  // Time in seconds the text stays hidden

     public float appearDuration2 = 2f;  // Time in seconds the text stays visible
    public float disappearDuration2 = 2f;  // Time in seconds the text stays hidden

    private void Start()
    {
        // Start the repeating coroutine
        StartCoroutine(ToggleText());
    }

    private IEnumerator ToggleText()
    {
        while (true) // Loop indefinitely
        {
            // Show the text
            textToToggle.gameObject.SetActive(true);
            yield return new WaitForSeconds(appearDuration);

             textToToggle2.gameObject.SetActive(true);
            yield return new WaitForSeconds(appearDuration2);

            // Hide the text
            textToToggle.gameObject.SetActive(false);
            yield return new WaitForSeconds(disappearDuration);

             textToToggle2.gameObject.SetActive(false);
            yield return new WaitForSeconds(disappearDuration2);
        }
    }
}
