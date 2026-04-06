using System.IO;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Vector2 _direction;


    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

}
