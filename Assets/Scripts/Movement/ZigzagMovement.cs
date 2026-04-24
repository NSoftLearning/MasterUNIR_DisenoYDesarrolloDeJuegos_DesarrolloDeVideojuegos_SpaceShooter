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
        
        _spawnedTime = Time.time;   
    }

    public void Initialize(float amplitude, float forwardSpeed, float zigzagSpeed, bool inverted, Vector3 initialPosition)
    {
        _amplitude = amplitude;
        _forwardSpeed = forwardSpeed;
        _zigzagSpeed = zigzagSpeed;
        _inverted = inverted;
        _initialPosition = initialPosition;
    }

    void Update()
    {
        //Time.time - _spawnedTime --> para que empiecen en un punto de la onda dependiente del momento de spawneo
        //*zigzagspeed --> se mueven mas rapido por la onda
        //+_initialPosition.y --> oscilan en torno al punto de spawneo

        float calculatedCos = Mathf.Cos((Time.time - _spawnedTime) * _zigzagSpeed);
        if (_inverted)
            calculatedCos *= -1;
        float calculatedY = calculatedCos * _amplitude + _initialPosition.y;
        
        transform.position = new Vector3(transform.position.x + _forwardSpeed * Time.deltaTime, calculatedY, _initialPosition.z);         
    }
}
