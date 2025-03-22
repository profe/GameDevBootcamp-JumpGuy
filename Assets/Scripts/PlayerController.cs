using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _isInAir;
    private bool _isFacingRight = true;
    private int _hitsTaken;

    [SerializeField] private float _jumpStrength;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _hitsCanTake = 1;
    //GAME OBJECTS
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Rigidbody2D _playerRigidBody;
    [SerializeField] private Transform _spawnPoint;

    /*
        void Start()
        {
            _isFacingRight = true;
            Spawn();
        }
    */

    void Update()
    {
        TryRunning();
        TryJumping();
    }

    public void TouchedGround()
    {
        _isInAir = false;
        _playerAnimator.SetBool("isGrounded", true);
    }

    private void TryJumping()
    {
        //JUMP KEY
        if (!_isInAir && Input.GetKeyDown(KeyCode.Space))
        {
            DoJumpForce();
        }
    }

    private void JumpSettings()
    {
        _soundManager.PlaySound("jump");
        _isInAir = true;
        _playerAnimator.SetTrigger("Jump");
    }

    public void AddForce(Vector2 vector, ForceMode2D forceMode)
    {
        _playerRigidBody.AddForce(vector, forceMode);
    }

    public void DoJumpForce()
    {
        JumpSettings();
        AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);
    }
    public void DoSmallJumpForce()
    {
        JumpSettings();
        AddForce(Vector2.up * _jumpStrength / 2, ForceMode2D.Impulse);
    }

    private void TryRunning()
    {
        //SHIFT / SUPER RUN
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            _moveSpeed *= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            _moveSpeed /= 2;
        }

        //RIGHT ARROW
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!_isFacingRight)
            {
                Flip();
            }
            _playerAnimator.SetBool("isRunning", true);
            _playerTransform.position += Vector3.right * _moveSpeed * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _playerAnimator.SetBool("isRunning", false);
        }

        //LEFT ARROW
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (_isFacingRight)
            {
                Flip();
            }
            _playerAnimator.SetBool("isRunning", true);
            _playerTransform.position += Vector3.left * _moveSpeed * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _playerAnimator.SetBool("isRunning", false);
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 theScale = _playerTransform.localScale;
        theScale.x *= -1;
        _playerTransform.localScale = theScale;
    }

    public void TakeHit()
    {
        _hitsTaken++;
        if (_hitsTaken >= _hitsCanTake)
        {
            Respawn();
        }
    }

    //general stuff and/or first time
    public void Spawn()
    {
        _isInAir = true;
        _hitsTaken = 0;
        _playerTransform.position = _spawnPoint.position;
        if (!_isFacingRight)
        {
            Flip();
        }
    }

    //usually called after losing a life
    public void Respawn()
    {
        _scoreManager.NumLives--;
        Spawn();
        _soundManager.PlaySound("respawn");
        //should i respawn enemies too?
    }


}
