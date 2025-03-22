using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private TMP_Text _finalScoreText;

    [SerializeField] private GameObject _levelCompleteCanvas;
    [SerializeField] private TMP_Text _completedfinalScoreText;

    void Start()
    {
        ResetUIs();
    }

    public void ResetUIs()
    {
        _gameOverCanvas.SetActive(false);
        _levelCompleteCanvas.SetActive(false);
    }

    public void ShowGameOverUI(int finalScore)
    {
        _gameOverCanvas.SetActive(true);
        _finalScoreText.text = finalScore.ToString();
    }

    public void ShowLevelCompleteUI(int completedScore)
    {
        _levelCompleteCanvas.SetActive(true);
        _completedfinalScoreText.text = completedScore.ToString();
    }

}
