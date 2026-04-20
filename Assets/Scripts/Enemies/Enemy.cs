using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] DamageableType _damageableType;
    [SerializeField] int maxLife = 2;
    [SerializeField] int scoreProvided;
    [SerializeField] int currencyProvided;

    
    [SerializeField] int _currentLife;

    public UnityEvent<EnemyDeadData> enemyDied;
    public UnityEvent ememyDamaged;
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
        else
        {
            ememyDamaged.Invoke();
        }            
    }
}
