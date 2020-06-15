using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Level01_GUIManager guiManager;

    private int collectedCoins = 0;

    public void UpdateCollectedCoins()
    {
        collectedCoins += 1;
        guiManager.UpdateCollectedCoins(collectedCoins);
    }
}
