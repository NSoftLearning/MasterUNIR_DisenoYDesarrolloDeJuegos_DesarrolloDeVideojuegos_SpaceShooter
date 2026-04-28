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
    public event Action PlayerDiedAction;
    public event Action <PlayerStatusData> PlayerDamagedAction;
    [SerializeField] float _afterHitInvulnerabilityTime = 2;
    [SerializeField] Collider2D _collider;

    float _invulnerableUntil;

    public event Action<DamageableDestroyedData> damageableDiedAction;

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
            PlayerDiedAction.Invoke();
            gameObject.SetActive(false);
        }
        else
        { 
            PlayerDamagedAction.Invoke  (new PlayerStatusData(_afterHitInvulnerabilityTime, _maxLife, _currentLife));
        }
    }

    public void MakePlayerInvulnerable()
    {
        _collider.enabled = false;
        _invulnerableUntil += Time.time + 5000;

    }
}
