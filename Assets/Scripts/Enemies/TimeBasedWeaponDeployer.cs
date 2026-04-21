using UnityEngine;

public class TimeBasedWeaponDeployer : MonoBehaviour
{
    [SerializeField] GameObject _weapon;
    [SerializeField] float _initialDelay;
    [SerializeField] float _burstDelay;


    float nextFireTime;
    private void Start()
    {
        nextFireTime = Time.time + _initialDelay;
    }

    private void Update()
    {
        if (Time.time < nextFireTime)
            return;


        Instantiate(_weapon, transform.position, transform.rotation);
        nextFireTime = Time.time + _burstDelay;
    }

}
