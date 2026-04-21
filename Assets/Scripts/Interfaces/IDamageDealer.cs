using NUnit.Framework;
using System.Collections.Generic;

public interface IDamageDealer
{
    int Strength { get; }
    List<DamageableTypeSO> ValidTargets { get;}
}