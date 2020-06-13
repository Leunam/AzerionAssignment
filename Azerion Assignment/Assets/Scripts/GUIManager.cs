using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    public void Button_Play()
    {
        SceneManager.LoadScene("Level_01");
    }
}
