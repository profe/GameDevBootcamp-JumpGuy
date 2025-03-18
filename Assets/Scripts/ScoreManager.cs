using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;

    [SerializeField]
    private int _numLivesStart = 3,
    _coinValue = 10,
    _livesValue = 50,
    _smushedValue = 5;

    private int _totalScore;

    private int _numCoins, _numLives, _numSmushed;

    public UnityEvent<int> OnNumLivesChanged;
    public UnityEvent<int> OnNumCoinsChanged;
    public UnityEvent<int> OnNumSmushedChanged;

    //PROPERTIES
    public int NumCoins
    {
        get
        {
            return _numCoins;
        }
        set
        {
            _numCoins = value;
            OnNumCoinsChanged.Invoke(_numCoins);
        }
    }
    public int NumLives
    {
        get
        {
            return _numLives;
        }
        set
        {
            _numLives = value;
            OnNumLivesChanged.Invoke(_numLives);
            if (_numLives == 0)
            {
                _gameManager.GameOver();
            }
        }
    }
    public int NumSmushed
    {
        get
        {
            return _numSmushed;
        }
        set
        {
            _numSmushed = value;
            OnNumSmushedChanged.Invoke(_numSmushed);
        }
    }

    void Start()
    {
        ResetScore();
    }

    public int CalculateTotalScore()
    {
        _totalScore = NumCoins * _coinValue + NumLives * _livesValue + NumSmushed * _smushedValue;

        return _totalScore;
    }

    public void ResetScore()
    {
        _totalScore = 0;
        NumCoins = 0;
        NumLives = _numLivesStart;
        NumSmushed = 0;
    }
}
