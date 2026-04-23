using UnityEngine;
using UnityEngine.Rendering;

public class Mine : MonoBehaviour
{
    [SerializeField] int _persistenceTime;

    float _destroyAtSecond;
    private void Start()
    {
        _destroyAtSecond = Time.time + _persistenceTime;
    }

    private void Update()
    {
        if (Time.time > _destroyAtSecond)
        {
            Destroy(gameObject);
        }
    }
}
