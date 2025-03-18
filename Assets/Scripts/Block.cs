using UnityEngine;

public class Block : MonoBehaviour
{
    private PlayerController _playerController;
    private ScoreManager _scoreManager;

    [SerializeField] private AudioSource _breakSound, _coinSound;

    void Start()
    {
        _playerController = FindFirstObjectByType<PlayerController>();
        _scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direction = collision.GetContact(0).normal;

            //check if colliding with bottom
            //  break block
            if (direction.y == 1)
            {
                HandleSpecificBlock();
                //add force down to simulate player hitting and being pushed down after hit
                _playerController.AddForce(Vector2.down, ForceMode2D.Impulse);
            }

            //check if colliding with top
            //  allow them to jump again
            if (direction.y == -1)
            {
                _playerController.TouchedGround();
            }
        }
    }

    private void HandleSpecificBlock()
    {
        if (gameObject.CompareTag("CoinBlock"))
        {
            BreakCoinBlock();
        }
        else if (gameObject.CompareTag("BrickBlock"))
        {
            BreakBrickBlock();
        }
    }

    private void BreakCoinBlock()
    {
        AudioSource.PlayClipAtPoint(_coinSound.clip, Vector3.down);
        _scoreManager.NumCoins++;

        BreakBrickBlock();
    }

    private void BreakBrickBlock()
    {
        AudioSource.PlayClipAtPoint(_breakSound.clip, Vector3.down);
        //hide/animate break block
        //Destroy(gameObject);
        gameObject.SetActive(false); //replaced destroy line to make respawning easier!
    }
}
