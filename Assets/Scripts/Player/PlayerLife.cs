using UnityEngine;
using UnityEngine.Events;

public class PlayerLife : MonoBehaviour, IDamageable
{
    [SerializeField] DamageableType _damageableType;
    [SerializeField] int maxLife;
    [SerializeField] UnityEvent PlayerDied;

    int _currentLife;
    
    public DamageableType Type => _damageableType;

    public void ReceiveDamage(IDamageDealer damageDealer)
    {
        _currentLife -= damageDealer.Strength;
        if (_currentLife <= 0)
        {
            PlayerDied.Invoke();
            Destroy(gameObject);
        }
    }
}
