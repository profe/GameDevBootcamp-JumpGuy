using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private TMP_Text _finalScoreText;

    void Start()
    {
        ResetUIs();
    }

    public void ResetUIs()
    {
        _gameOverCanvas.SetActive(false);
    }

    public void ShowGameOverUI(int finalScore)
    {
        _gameOverCanvas.SetActive(true);
        _finalScoreText.text = finalScore.ToString();
    }

}
