using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
   DamageableType Type { get; }

    void ReceiveDamage(IDamageDealer damageDealer);
}
