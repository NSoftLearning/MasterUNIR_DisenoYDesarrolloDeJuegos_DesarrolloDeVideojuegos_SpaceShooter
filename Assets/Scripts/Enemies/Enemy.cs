using NUnit.Framework;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] DamageableType _damageableType;
    [SerializeField] int maxLife = 2;

    int _currentLife;


    private void Start()
    {
        _currentLife = maxLife;
    }

    public DamageableType Type => _damageableType;
    
    public void ReceiveDamage(IDamageDealer damageDealer)
    {
        _currentLife -= damageDealer.Strength;
        if (_currentLife < 0)
        {
            //evento enemigo destruido
            Destroy(gameObject);
        }

    }
}
