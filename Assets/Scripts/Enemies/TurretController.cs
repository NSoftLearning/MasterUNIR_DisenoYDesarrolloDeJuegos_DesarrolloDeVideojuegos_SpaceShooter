using UnityEngine;
using UnityEngine.Animations;

public class TurretController : MonoBehaviour
{
    
    [SerializeField] Transform _transformToRotate;
    Transform _targetTransform;


    private void Start()
    {
        _targetTransform = ComponentLocatorService.Components.PlayerTransform;
    }

    private void Update()
    {
        if (_transformToRotate == null)
            return;

        Vector3 direction = _targetTransform.position - _transformToRotate.position; 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
        _transformToRotate.rotation = Quaternion.Euler(0f, 0f, angle);                         
    }


}
