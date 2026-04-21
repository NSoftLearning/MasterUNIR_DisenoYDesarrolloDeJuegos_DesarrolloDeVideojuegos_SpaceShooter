using NUnit.Framework;
using System;
using System.Collections.Generic;

public interface IDamageDealer
{
    int Strength { get; }
    List<DamageableTypeSO> ValidTargets { get;}
    event Action validTargetHit;
}