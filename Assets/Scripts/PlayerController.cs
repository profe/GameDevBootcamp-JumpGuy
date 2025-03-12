using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _isInAir;
    private bool _isFacingRight;

    [SerializeField] private float _jumpStrength;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _numCollectibles;
    //GAME OBJECTS    
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Rigidbody2D _playerRigidBody;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private AudioSource _jumpSound;

    void Start()
    {
        _isInAir = false;
        _isFacingRight = true;
        _jumpSound = GetComponent<AudioSource>();
    }

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
            _jumpSound.Play();
            _isInAir = true;
            _playerAnimator.SetTrigger("Jump");
            _playerRigidBody.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);
        }
    }

    private void TryRunning()
    {
        //RIGHT ARROW
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!_isFacingRight)
            {
                Flip();
            }
            _playerAnimator.SetBool("isRunning", true);
            _playerTransform.position += Vector3.right * _moveSpeed;
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
            _playerTransform.position += Vector3.left * _moveSpeed;
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

    public void GetCollectible()
    {
        _numCollectibles++;
        //update visuals later
    }

    public void Respawn()
    {
        //sound was already played
        //add pause?
        //change UI (like decrementing lives or points)
        if (!_isFacingRight)
        {
            Flip();
        }
        _playerTransform.position = _spawnPoint.position;
    }
}
