using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomRespawn : MonoBehaviour
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
            _playerController.Respawn();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            //destroy enemy (dont respawn) that fell but dont add to score manager!
            Destroy(collision.gameObject);
        }
    }
}
