

using System;
using UnityEngine;

public class DestroyedBasedWeaponDeployerControl : MonoBehaviour, IWeaponDeployerControl
{
    [SerializeField] [Range(0,100)] int _deploymendProbability;
    IDamageable _damageable;


    public event Action DeployWeapon;


    void Awake ()
    {
        _damageable = GetComponentInParent<IDamageable>();
    }



    public void Update()
    {
        Debug.Log("");
    }

    public void HandleDamageableDestroyed (DamageableDestroyedData data)
    {
        if (UnityEngine.Random.Range(0, 100) <= _deploymendProbability)
            DeployWeapon.Invoke();
    }
    void OnEnable()
    {
        _damageable.enemyDiedAction += HandleDamageableDestroyed;
    }

    private void OnDisable()
    {
        _damageable.enemyDiedAction -= HandleDamageableDestroyed;
    }

}
