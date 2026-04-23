using System;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    DamageableTypeSO Type { get; }
    bool UnderTemporalDamageProtection { get; }

    void ReceiveDamage(IDamageDealer damageDealer);
}
