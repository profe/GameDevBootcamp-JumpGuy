using UnityEngine;

public class Tube : MonoBehaviour
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
            Vector2 direction = collision.GetContact(0).normal;

            //check if colliding with top
            //  allow them to jump again
            if (direction.y == -1)
            {
                //Debug.Log("top");
                _playerController.TouchedGround();
            }
        }
    }
}
