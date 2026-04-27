using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DoubleAreaDamage : MonoBehaviour, IDamageDealer
{
    [Header ("Settings")]
    [SerializeField] float _fuseDelay;
    [SerializeField] float _damageRadius = 5;
    [SerializeField] List<DamageableTypeSO> validTargets;
    [SerializeField] int _strength;
    [SerializeField] ExplosionFX _explosionFX;


    [Header ("Watch only")]
    [SerializeField] bool _fuseActivated;
    [SerializeField] float _detonateAtSecond;

    public event Action validTargetHit;

    public int Strength => _strength;

    public List<DamageableTypeSO> ValidTargets => throw new NotImplementedException();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_fuseActivated)
            return;

        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable == null ||
           !validTargets.Contains(damageable.Type))
            return;

        _fuseActivated = true;
        _detonateAtSecond = Time.time + _fuseDelay;

    }

    void Update ()
    {
        if (!_fuseActivated)
            return;

        if (Time.time >= _detonateAtSecond)
            DealDamageToValidTargets();


    }


    void DealDamageToValidTargets() 
    {
        Collider2D[] collidersFound =   Physics2D.OverlapCircleAll(transform.position, _detonateAtSecond);

      foreach (Collider2D collider in collidersFound)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();
            if (damageable == null||
                !validTargets.Contains(damageable.Type) ||
                damageable.UnderTemporalDamageProtection)
                continue;

            damageable.ReceiveDamage(this);
        }

        validTargetHit.Invoke();

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.orangeRed;
        Gizmos.DrawWireSphere(transform.position, _damageRadius);

    }
}
