using UnityEngine;

public class ExitController : MonoBehaviour
{
    public Level01_GUIManager guiManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            guiManager.ActivateLevelCompletedPanel();
        }
    }
}
