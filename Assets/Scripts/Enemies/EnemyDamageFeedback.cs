using System.Collections;
using UnityEngine;

public class EnemyDamageFeedback : MonoBehaviour
{
    [SerializeField] SpriteRenderer _enemySpriteRenderer;
    [SerializeField] Color _normalColor = Color.white;
    [SerializeField] Color _damageColor = Color.red;
    [SerializeField] float _colorChangeDuration = 1;
    [SerializeField] float _inDamagedColorDuration = .2f;
    [SerializeField] ExplosionFX _destroyedFX;
    [SerializeField] AudioClip _receiveDamageClip;
    [SerializeField] AudioClip _destroyedAudioClip;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] float _explosionScale = 1;
    Enemy _enemy;
    Coroutine colorChangeCorroutine;
    float effectStartTime;
    float effectEndTime;


    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    public void ShowDamageFeedback()
    {
        if (colorChangeCorroutine != null)
            StopCoroutine(colorChangeCorroutine);

        _enemySpriteRenderer.color = _damageColor;
        effectStartTime = Time.time;
        effectEndTime = Time.time + _colorChangeDuration + _inDamagedColorDuration;
        colorChangeCorroutine = StartCoroutine(BackToNormalColor());


        _audioSource.clip = _receiveDamageClip;
        _audioSource.Play();
    }

    public void ShowDestroyedFeedback(EnemyDeadData eneyDeadData)
    {
        ExplosionFX explosion = Instantiate(_destroyedFX, transform.position, Quaternion.identity);
        explosion.Initialize(_destroyedAudioClip, Vector3.one * _explosionScale);
    }

    IEnumerator BackToNormalColor ()
    {
        yield return new WaitForSeconds(_inDamagedColorDuration);
        while (Time.time < effectEndTime)
        {
            _enemySpriteRenderer.color = Color.Lerp(_damageColor, _normalColor, (Time.time - effectStartTime) / _colorChangeDuration);          
            yield return null;
        }
    }

    private void OnEnable()
    {
        _enemy.enemyDamagedAction += ShowDamageFeedback;
        _enemy.enemyDiedAction += ShowDestroyedFeedback;
;
}

    private void OnDisable()
    {
        _enemy.enemyDamagedAction -= ShowDamageFeedback;
        _enemy.enemyDiedAction -= ShowDestroyedFeedback;

    }

}
