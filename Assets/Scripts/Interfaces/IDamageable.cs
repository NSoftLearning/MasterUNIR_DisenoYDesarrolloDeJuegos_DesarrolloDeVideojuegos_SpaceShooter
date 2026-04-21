using System;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
   DamageableTypeSO Type { get; }

    void ReceiveDamage(IDamageDealer damageDealer);
}
