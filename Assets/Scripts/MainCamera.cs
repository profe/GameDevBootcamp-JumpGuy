using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private int _deltaX;

    private float _minX;

    public void Start()
    {
        _minX = transform.position.x;
    }

    // called after Update() method, recommended for camera scripts
    public void LateUpdate()
    {
        transform.position = new Vector3(CalculateX(), transform.position.y, transform.position.z);
    }

    private float CalculateX()
    {
        float newX = _player.transform.position.x + _deltaX * Time.deltaTime;
        //adjust X position for camera to avoid camera going too far left
        if (newX < _minX)
        {
            newX = _minX;
        }
        //can also add check for going too far right later here

        return newX;
    }
}
