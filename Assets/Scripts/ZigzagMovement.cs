using UnityEngine;

public class ZigzagMovement : MonoBehaviour
{
    [SerializeField] float _amplitude;
    [SerializeField] float _forwardSpeed;
    [SerializeField] float _zigzagSpeed;
    [SerializeField] bool _inverted;

    
    Vector3 _initialPosition;
    float _spawnedTime;
    void Start()
    {
        _initialPosition = transform.position;
        _spawnedTime = Time.time; 
    }

    public void Initialize(float amplitude, float forwardSpeed, float zigzagSpeed, bool inverted)
    {
        _amplitude = amplitude;
        _forwardSpeed = forwardSpeed;
        _zigzagSpeed = zigzagSpeed;
        _inverted = inverted;        
    }

    void Update()
    {
        //Time.time - _spawnedTime --> para que empiecen en un punto de la onda dependiente del momento de spawneo
        //*zigzagspeed --> se mueven mas rapido por la onda
        //+_initialPosition.y --> oscilan en torno al punto de spawneo
        float calculatedY = Mathf.Sin((Time.time - _spawnedTime) * _zigzagSpeed) * _amplitude + _initialPosition.y;
        if (_inverted)
            calculatedY *= -1;
        transform.position = new Vector3(transform.position.x + _forwardSpeed * Time.deltaTime, calculatedY, _initialPosition.z);         
    }
}
