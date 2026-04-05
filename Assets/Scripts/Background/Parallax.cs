using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _imageWidth;

    private Vector3 _initialPosition;
    
    public void Start()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        float module = (_speed * Time.time) % _imageWidth;
        transform.position = _initialPosition + module * _direction;
    }
}
