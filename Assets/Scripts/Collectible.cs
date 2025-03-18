using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private ScoreManager _scoreManager;
    private AudioSource _coinSound;

    void Start()
    {
        _scoreManager = FindFirstObjectByType<ScoreManager>();
        _coinSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //_coinSound.Play(); doesnt allow to play AND destroy object, below is fix
            AudioSource.PlayClipAtPoint(_coinSound.clip, Vector3.down);
            _scoreManager.NumCoins++;
            //Destroy(gameObject);
            gameObject.SetActive(false); //replaced destroy line to make respawning easier!
        }
    }
}
