using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameManager _gameManager;
    private bool _isFacingLeft;

    [SerializeField] private float _moveSpeed;

    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
        _isFacingLeft = true;
    }

    void Update()
    {

        /*        if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (_isFacingRight)
                    {
                        Flip();
                    }
                    _playerAnimator.SetBool("isRunning", true);
                    _playerTransform.position += Vector3.left * _moveSpeed;
                }
                */
        if (_isFacingLeft)
        {
            transform.position += _moveSpeed * Time.deltaTime * Vector3.left;
        }
        else
        {
            transform.position += _moveSpeed * Time.deltaTime * Vector3.right;
        }
    }

    private void Flip()
    {
        _isFacingLeft = !_isFacingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //check if colliding with top
            //  bounce player off enemy, destroy this enemy
            Vector2 direction = (collision.gameObject.transform.position - gameObject.transform.position).normalized;
            if (direction.y > 0)
            {
                _gameManager.PlaySound("jump");
                _gameManager.DoSmallJumpForce();
                _gameManager.IncrementSmushed();
                Destroy(gameObject);
            }
            else //anywhere else should cause player damage
            {
                Debug.Log("hit by enemy!");
                _gameManager.TakeHit();
            }
        }
        else if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Obstacle"))
        {
            Flip();
        }
    }
}
