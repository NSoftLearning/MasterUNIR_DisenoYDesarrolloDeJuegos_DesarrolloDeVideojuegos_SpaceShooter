using System;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    DamageableTypeSO Type { get; }
    bool UnderTemporalDamageProtection { get; }
    public event Action<DamageableDestroyedData> damageableDiedAction;

    void ReceiveDamage(IDamageDealer damageDealer);
}
