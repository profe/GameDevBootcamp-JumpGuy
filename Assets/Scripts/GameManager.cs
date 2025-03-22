using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isGamePlaying = false;

    //GAME OBJECTS
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private Transform _collectibleParent, _breakablesParent, _enemiesParent;

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        UnpauseGame();
        _isGamePlaying = true;
        ResetAll();
    }

    public void ResetAll()
    {
        _uiManager.ResetUIs();
        _scoreManager.ResetScore();
        _playerController.Spawn();
    }

    public int CalculateFinalScore()
    {
        return _scoreManager.CalculateTotalScore();
    }

    public void GameOver()
    {
        Debug.Log("Starting game over!");
        PlaySound("game_over");

        //display menu screen to try again
        PauseGame();
        _uiManager.ShowGameOverUI(_scoreManager.CalculateTotalScore());
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _isGamePlaying = false;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        _isGamePlaying = true;
    }


    // DELEGATE METHODS

    public void PlaySound(string soundName)
    {
        _soundManager.PlaySound(soundName);
    }

    public void IncrementCoin()
    {
        _scoreManager.NumCoins++;
    }

    public void AddForce(Vector2 vector, ForceMode2D forceMode)
    {
        _playerController.AddForce(vector, forceMode);
    }

    public void TouchedGround()
    {
        _playerController.TouchedGround();
    }

    public void DoSmallJumpForce()
    {
        _playerController.DoSmallJumpForce();
    }

    public void IncrementSmushed()
    {
        _scoreManager.NumSmushed++;
    }

    public void TakeHit()
    {
        _playerController.TakeHit();
    }
}
