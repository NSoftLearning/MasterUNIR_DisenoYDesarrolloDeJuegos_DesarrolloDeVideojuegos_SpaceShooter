using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLife : MonoBehaviour, IDamageable
{
    [Header("Watch only")]
    [SerializeField] int _currentLife;
    [Header("Config")]
    [SerializeField] DamageableTypeSO _damageableType;
    [SerializeField] int _maxLife;
    [SerializeField] UnityEvent _PlayerDied;
    [SerializeField] UnityEvent <PlayerStatusData> _PlayerDamaged;
    [SerializeField] float _afterHitInvulnerabilityTime = 2;


    float _invulnerableUntil;


    public DamageableTypeSO Type => _damageableType;

    public bool UnderTemporalDamageProtection => _invulnerableUntil > Time.time;

    void Start ()
    {
        _currentLife = _maxLife;
        _invulnerableUntil = Time.time;
    }

    public void ReceiveDamage(IDamageDealer damageDealer)
    {
        if (Time.time <= _invulnerableUntil)
            return;


        _currentLife -= damageDealer.Strength;
        _invulnerableUntil = Time.time + _afterHitInvulnerabilityTime;
        if (_currentLife <= 0)
        {
            _PlayerDied.Invoke();
            
            Destroy(gameObject);
        }
        else
        {
            _PlayerDamaged.Invoke(new PlayerStatusData(_afterHitInvulnerabilityTime, _maxLife, _currentLife));
        }
    }
}
