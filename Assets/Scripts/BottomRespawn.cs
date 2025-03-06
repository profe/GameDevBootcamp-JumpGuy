using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomRespawn : MonoBehaviour
{
    private PlayerController _playerController;
    private AudioSource _respawnSound;

    void Start()
    {
        _playerController = FindFirstObjectByType<PlayerController>();
        _respawnSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _respawnSound.Play();
            _playerController.Respawn();
        }
    }
}
