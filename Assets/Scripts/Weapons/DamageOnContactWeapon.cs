using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageOnContactWeapon : MonoBehaviour, IDamageDealer
{
    [SerializeField] List <DamageableTypeSO> validtargets;
    [SerializeField] int _strength;
    [SerializeField] bool _selfDestroyOnHit = false;

    
    public List<DamageableTypeSO> ValidTargets => validtargets;
    public int Strength => _strength;
    public event Action validTargetHit;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageableHit = collision.GetComponent<IDamageable>();

        if (damageableHit == null ||
            !ValidTargets.Contains(damageableHit.Type) ||
            damageableHit.UnderTemporalDamageProtection)
            return;

        damageableHit.ReceiveDamage(this);
        validTargetHit?.Invoke();

        if (_selfDestroyOnHit)
            Destroy(gameObject);
    }
}
