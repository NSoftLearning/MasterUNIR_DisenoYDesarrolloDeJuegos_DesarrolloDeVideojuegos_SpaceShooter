using System;
using UnityEngine;

public class EnemyKamikazeFeedback : MonoBehaviour
{
    [SerializeField] ExplosionFX _explosionFX;
    [SerializeField] AudioClip _hitTargetClip;

    IDamageDealer _damageDealer;

    private void Awake()
    {
       // _damageDealer = GetComponent<IDamageDealer>();
    }


    private void ShowHitFeedback()
    {
     //   ExplosionFX explosionFX = Instantiate(_explosionFX, transform.position, Quaternion.identity);
     //   explosionFX.Initialize(_hitTargetClip, Vector2.one);
    }


    private void OnEnable()
    {
      //  _damageDealer.validTargetHit += ShowHitFeedback;
    }

    private void OnDisable()
    {
      //  _damageDealer.validTargetHit -= ShowHitFeedback;
    }


}
