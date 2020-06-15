using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level01_GUIManager : MonoBehaviour
{

    public GameObject levelCompletedPanel;
    public TextMeshProUGUI uiCoins;

    public void ActivateLevelCompletedPanel()
    {
        if (!levelCompletedPanel.activeInHierarchy)
        {
            levelCompletedPanel.SetActive(true);
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateCollectedCoins(int collectedCoins)
    {
        uiCoins.text = collectedCoins.ToString();
    }
}
