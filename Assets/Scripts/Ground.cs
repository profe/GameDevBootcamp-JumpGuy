using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private PlayerController _playerController;

    void Start()
    {
        _playerController = FindFirstObjectByType<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerController.TouchedGround();
        }
    }

}
