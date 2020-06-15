using UnityEngine;
using UnityEngine.SceneManagement;

public class Level01_GUIManager : MonoBehaviour
{

    public GameObject levelCompletedPanel;

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
}
