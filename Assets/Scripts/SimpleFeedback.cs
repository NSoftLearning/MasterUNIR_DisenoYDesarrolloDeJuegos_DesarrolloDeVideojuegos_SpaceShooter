using UnityEngine;

public class SimpleFeedback : MonoBehaviour
{
    [SerializeField] ExplosionFX _explosion;
    [SerializeField] IDamageDealer  _damageDealer;
    [SerializeField] AudioClip _audioClip;


    private void Awake()
    {
        _damageDealer = GetComponent<IDamageDealer>();
    }
    private void OnEnable()
    {
        _damageDealer.validTargetHit += ShowFeedback;
    }

    private void OnDisable()
    {
        _damageDealer.validTargetHit -= ShowFeedback;
    }
    public void ShowFeedback ()
    {
        ExplosionFX newExplosion= Instantiate(_explosion, transform.position, Quaternion.identity);
        newExplosion.Initialize(_audioClip, Vector3.one * 2);
    }
}
