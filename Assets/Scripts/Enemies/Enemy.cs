using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] DamageableTypeSO _damageableType;
    [SerializeField] int maxLife = 2;
    [SerializeField] int scoreProvided;
    [SerializeField] int currencyProvided;
   
    
    [SerializeField] int _currentLife;

   // public UnityEvent<EnemyDeadData> enemyDied_UNITYEVENT;
   // public UnityEvent ememyDamaged_UNITYEVENT;

    public event Action<EnemyDeadData> enemyDiedAction;
    public event Action enemyDamagedAction;

    

    private void Start()
    {
        _currentLife = maxLife;
    }

    public DamageableTypeSO Type => _damageableType;

    public bool UnderTemporalDamageProtection => false;

    public void ReceiveDamage(IDamageDealer damageDealer)
    {
        _currentLife -= damageDealer.Strength;
        if (_currentLife <= 0)
        {            
            //enemyDied_UNITYEVENT.Invoke(new EnemyDeadData (scoreProvided, currencyProvided));
            enemyDiedAction.Invoke(new EnemyDeadData(scoreProvided, currencyProvided));
            Destroy(gameObject);
        }
        else
        {
           // ememyDamaged_UNITYEVENT.Invoke();
            enemyDamagedAction.Invoke();
        }            
    }
}
