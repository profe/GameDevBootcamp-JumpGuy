using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isGamePlaying = false;

    //GAME OBJECTS
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private AudioSource _gameOverAudioSource;
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
        _gameOverAudioSource.Stop(); //incase its playing from a quick restart of the game
        _uiManager.ResetUIs();
        _scoreManager.ResetScore();
        ResetInteractables();
        _playerController.Spawn();
    }

    //NOTE: just sets all objects to active. should probably replace all enemies/collectibles/breakables with spawn points? or easier way?
    public void ResetInteractables()
    {
        //respawn all enemies
        for (int i = 0; i < _collectibleParent.childCount; i++)
        {
            _collectibleParent.GetChild(i).GetComponent<Transform>().gameObject.SetActive(true);
        }
        //restore all breakables
        for (int i = 0; i < _breakablesParent.childCount; i++)
        {
            _breakablesParent.GetChild(i).GetComponent<Transform>().gameObject.SetActive(true);
        }
        //restore all collectibles
        for (int i = 0; i < _enemiesParent.childCount; i++)
        {
            _enemiesParent.GetChild(i).GetComponent<Transform>().gameObject.SetActive(true);
        }
    }

    public int CalculateFinalScore()
    {
        return _scoreManager.CalculateTotalScore();
    }

    public void GameOver()
    {
        Debug.Log("Starting game over!");
        //play game over music
        _gameOverAudioSource.Play();
        _isGamePlaying = false;

        //display menu screen to try again
        PauseGame();
        _uiManager.ShowGameOverUI(_scoreManager.CalculateTotalScore());
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        //show pause menu
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        //hide pause menu
    }
}
