using UnityEngine;

public class FlagPole : MonoBehaviour
{
    [SerializeField] private GameObject _finishedFlag;

    private GameManager _gameManager;

    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //check which part of pole is touched to determine number of points
            Vector2 direction = (collision.gameObject.transform.position - gameObject.transform.position).normalized;
            int poleHeight = Mathf.RoundToInt(collision.transform.position.y + 3); //lowest is 0.0186, highest is 4.285 when shifted by 3, so rounds 0 to 5 basically
            Vector3 flagPosition = new Vector3(_finishedFlag.transform.position.x,
                collision.transform.position.y, //change height to where collision happened
                _finishedFlag.transform.position.z);

            //show+animate flag
            _finishedFlag.SetActive(true);
            //_finishedFlag.transform.position = flagPosition; //no animation
            _finishedFlag.transform.position = Vector3.Lerp(_finishedFlag.transform.position, flagPosition, 1.0f);

            //show end screen with score and button for next level
            _gameManager.CompletedLevel(poleHeight);
        }
    }
}
