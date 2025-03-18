using TMPro;
using UnityEngine;

public class FooterUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _numLives;
    [SerializeField] TextMeshProUGUI _numCoins;
    [SerializeField] TextMeshProUGUI _numSmushed;


    public void UpdateLives(int lives)
    {
        _numLives.text = lives.ToString();
        //maybe change color based on how close you are to 0?
    }

    public void UpdateCoins(int coins)
    {
        _numCoins.text = coins.ToString();
    }

    public void UpdateSmushed(int smushed)
    {
        _numSmushed.text = smushed.ToString();
    }
}
