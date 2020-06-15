using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    static AnalyticsManager instance;

    public static AnalyticsManager Instance { get { return instance; } }

    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// To Call this method just write method call passing the relevant parameters/variables:
    /// AnalyticsManager.Instance.GameOver_Event(collectedCoins, distanceTraveled, killedEnemies, Xp, deathSection);
    /// </summary>
    /// <param name="collectedCoins"></param>
    /// <param name="distanceTraveled"></param>
    /// <param name="killedEnemies"></param>
    /// <param name="lastXp"></param>
    /// <param name="currentSection"></param>
    public void GameOver_Event(int collectedCoins, int distanceTraveled, int killedEnemies, int lastXp, int currentSection)
    {
        Analytics.CustomEvent("Game Over", new Dictionary<string, object>
        {
            {"collectedCoins", collectedCoins },
            {"DistanceTraveled", distanceTraveled},
            {"TotalKills", killedEnemies},
            {"XpGained", lastXp},
            {"sectionOfDeath", currentSection }
        });
    }

    //Another example like the previous one
    public void Level_Cleared_Event(int collectedCoins, int distanceTraveled, int killedEnemies, int lastXp, string stage)
    {
        Analytics.CustomEvent("Stage Cleared", new Dictionary<string, object>
        {
            {"collectedCoins", collectedCoins },
            {"lastDistance", distanceTraveled},
            {"lastScore", killedEnemies},
            {"lastXP",lastXp },
            {"stage",stage }
        });
    }

    /// <summary>
    /// To get and register the User Device model.
    /// </summary>
    public void DeviceModel_Event()
    {

        Analytics.CustomEvent("DeviceModel", new Dictionary<string, object>
        {
            {"device",SystemInfo.deviceModel }
        });

    }
}
