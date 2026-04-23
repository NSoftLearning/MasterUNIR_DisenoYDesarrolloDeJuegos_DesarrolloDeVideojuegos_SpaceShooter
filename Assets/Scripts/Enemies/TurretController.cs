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

        Vector3 updatedDirection = _targetTransform.position - _transformToRotate.position;
        _transformToRotate.right = updatedDirection;                             
            
    }


}
