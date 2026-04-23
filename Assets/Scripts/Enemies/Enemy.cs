using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] DamageableTypeSO _damageableType;
    [SerializeField] int maxLife = 2;
    [SerializeField] int _scoreProvided;
    [SerializeField] int _currencyProvided;
    [SerializeField] int _damageOnHitWithPlayer = 100;
    
    [SerializeField] int _currentLife;

   // public UnityEvent<EnemyDeadData> enemyDied_UNITYEVENT;
   // public UnityEvent ememyDamaged_UNITYEVENT;

    public event Action<EnemyDeadData> enemyDiedAction;
    public event Action enemyDamagedAction;

    IDamageDealer _damageDealer;

    public void Awake()
    {
        _damageDealer = GetComponent<IDamageDealer>();
    }


    private void Start()
    {
        _currentLife = maxLife;
    }

    public DamageableTypeSO Type => _damageableType;

    public bool UnderTemporalDamageProtection => false;

    public void ReceiveDamage(IDamageDealer damageDealer)
    {
        ApplyDamage(damageDealer.Strength);
    }

    void ApplyDamage (int incomingDamage)
    {
        _currentLife -= incomingDamage;
        if (_currentLife <= 0)
        {
            //enemyDied_UNITYEVENT.Invoke(new EnemyDeadData (scoreProvided, currencyProvided));
            enemyDiedAction.Invoke(new EnemyDeadData(_scoreProvided, _currencyProvided));
            Destroy(gameObject);
        }
        else
        {
            // ememyDamaged_UNITYEVENT.Invoke();
            enemyDamagedAction.Invoke();
        }
    }
    private void ResolveHitWithTarget()
    {
        ApplyDamage(_damageOnHitWithPlayer);
    }
    public void OnEnable()
    {
        _damageDealer.validTargetHit += ResolveHitWithTarget;
    }



    public void OnDisable()
    {
        _damageDealer.validTargetHit += ResolveHitWithTarget;
    }

}
