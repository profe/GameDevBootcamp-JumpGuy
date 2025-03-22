using UnityEngine;

public class Block : MonoBehaviour
{
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
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
                _gameManager.AddForce(Vector2.down, ForceMode2D.Impulse);
            }

            //check if colliding with top
            //  allow them to jump again
            if (direction.y == -1)
            {
                _gameManager.TouchedGround();
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
        _gameManager.PlaySound("collectible");
        _gameManager.IncrementCoin();

        BreakBrickBlock();
    }

    private void BreakBrickBlock()
    {
        _gameManager.PlaySound("break_block");
        //hide/animate break block
        //Destroy(gameObject);
        gameObject.SetActive(false); //replaced destroy line to make respawning easier!
    }
}
