using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageOnContactWeapon : MonoBehaviour, IDamageDealer
{
    [SerializeField] List <DamageableTypeSO> validtargets;
    [SerializeField] int _strength;

    public List<DamageableTypeSO> ValidTargets => validtargets;
    public int Strength => _strength;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger", this);
        IDamageable damageableHit = collision.GetComponent<IDamageable>();

        if (damageableHit == null ||
            !ValidTargets.Contains(damageableHit.Type))
            return;

        damageableHit.ReceiveDamage(this);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision", this);
    }
}
