using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private PlayerController _playerController;
    private AudioSource _coinSound;

    void Start()
    {
        _playerController = FindFirstObjectByType<PlayerController>();
        _coinSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //_coinSound.Play(); doesnt allow to play AND destroy object, below is fix
            AudioSource.PlayClipAtPoint(_coinSound.clip, Vector3.down);
            _playerController.GetCollectible();
            Destroy(gameObject);
        }
    }
}
