using NUnit.Framework;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] DamageableType _damageableType;
    [SerializeField] int maxLife = 2;
    [SerializeField] int scoreProvided;
    [SerializeField] int currencyProvided;

    
    int _currentLife;

    public Action<EnemyDeadData> enemyDied;
    private void Start()
    {
        _currentLife = maxLife;
    }

    public DamageableType Type => _damageableType;
    
    public void ReceiveDamage(IDamageDealer damageDealer)
    {
        _currentLife -= damageDealer.Strength;
        if (_currentLife <= 0)
        {            
            enemyDied.Invoke(new EnemyDeadData (scoreProvided, currencyProvided));
            Destroy(gameObject);
        }
    }
}
