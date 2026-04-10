using NUnit.Framework;
using System.Collections.Generic;

public interface IDamageDealer
{
    int Strength { get; }
    List<DamageableType> ValidTargets { get;}
}