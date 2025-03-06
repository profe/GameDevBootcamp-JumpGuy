using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private PlayerController _playerController;
    private AudioSource _hitSound;

    void Start()
    {
        _playerController = FindFirstObjectByType<PlayerController>();
        _hitSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _hitSound.Play();
        }
    }
}
