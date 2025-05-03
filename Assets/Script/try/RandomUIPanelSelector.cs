//i wana say good bye 

using UnityEngine;

public class RandomUIPanelSelector : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public float displayTime = 2f;

    private GameObject selectedPanel;

    void Start()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);

        string currentPlayer = PlayerPrefs.GetString("CurrentPlayer", "");
        int selectedIndex = PlayerPrefs.GetInt("UIPanel_" + currentPlayer, -1);

        switch (selectedIndex)
        {
            case 0:
                selectedPanel = panel1;
                break;
            case 1:
                selectedPanel = panel2;
                break;
            case 2:
                selectedPanel = panel3;
                break;
            default:
                Debug.LogWarning("No UI panel index set for player: " + currentPlayer);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && selectedPanel != null)
        {
            selectedPanel.SetActive(true);
            Invoke(nameof(HidePanel), displayTime);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && selectedPanel != null)
        {
            selectedPanel.SetActive(false);
        }
    }

    private void HidePanel()
    {
        if (selectedPanel != null)
        {
            selectedPanel.SetActive(false);
        }
    }
}
 