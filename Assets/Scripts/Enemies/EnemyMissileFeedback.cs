using Unity.VisualScripting;
using UnityEngine;

public class EnemyMissileFeedback : MonoBehaviour
{
    [SerializeField] AcceleratedForwardMovementPhysics _missileMovement;
    [SerializeField] GameObject _reticle;
    [SerializeField] AudioSource _audioSource;

    [SerializeField] AudioClip _missileLaunchedWarning;
    [SerializeField] AudioClip _missileEngineClip;

    private void Start()
    {
        _audioSource.clip = _missileLaunchedWarning;
        _audioSource.Play();
    }

    public void HideReticle ()
    {
        _reticle.SetActive(false);
    }

    public void AccelerateMissile ()
    {
        _audioSource.clip = _missileEngineClip;
        _audioSource.Play();
    }

    private void OnEnable()
    {
        _missileMovement.maxSpeedReached += HideReticle;
        _missileMovement.accelerationStarted += AccelerateMissile;
            
    }

    private void OnDisable()
    {
        _missileMovement.maxSpeedReached -= HideReticle;
        _missileMovement.accelerationStarted -= AccelerateMissile;
    }
}
