using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        if (!gameManager)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    }

    //TODO: If I have time to implement the coins pooler...
    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.UpdateCollectedCoins();
            this.gameObject.SetActive(false);
        }
    }
}
