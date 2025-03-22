using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _gameManager.PlaySound("collectible");
            _gameManager.IncrementCoin();
            Destroy(gameObject);
        }
    }
}
