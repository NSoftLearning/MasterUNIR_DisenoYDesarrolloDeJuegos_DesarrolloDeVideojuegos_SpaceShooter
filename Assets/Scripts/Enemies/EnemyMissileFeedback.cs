using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMissileFeedback : MonoBehaviour
{
    [SerializeField] AcceleratedForwardMovementPhysics _missileMovement;
    [SerializeField] GameObject _reticle;
    [SerializeField] AudioSource _audioSource;

    [SerializeField] AudioClip _missileLaunchedWarning;
    [SerializeField] AudioClip _missileEngineClip;
    [SerializeField] AudioClip _destroyedAudioClip;
    [SerializeField] ExplosionFX _destroyedFX;

    IDamageDealer _damageDealer;

    private void Awake()
    {
        _damageDealer = GetComponent<IDamageDealer>();
    }
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
    private void ShowHitFeedback()
    {
        ExplosionFX explosion = Instantiate(_destroyedFX, transform.position, Quaternion.identity);
        explosion.Initialize(_destroyedAudioClip, Vector3.one * 2.5f);
    }
    private void OnEnable()
    {
        _missileMovement.maxSpeedReached += HideReticle;
        _missileMovement.accelerationStarted += AccelerateMissile;
        _damageDealer.validTargetHit += ShowHitFeedback;
     }

 

    private void OnDisable()
    {
        _missileMovement.maxSpeedReached -= HideReticle;
        _missileMovement.accelerationStarted -= AccelerateMissile;
        _damageDealer.validTargetHit -= ShowHitFeedback;
    }
}
