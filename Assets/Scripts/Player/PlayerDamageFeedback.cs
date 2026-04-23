using System.Collections;
using UnityEngine;

public class PlayerDamageFeedback : MonoBehaviour
{
    [SerializeField] SpriteRenderer _playerSpriteRenderer;
    [SerializeField] Color _invulnerableColor;
    [SerializeField] ExplosionFX _explosion;

    [SerializeField] AudioClip _reciveDamageClip;

    [SerializeField] AudioSource _audioSource;

    PlayerLife _playerLife;
    Coroutine stayTransparent;

    private void Awake()
    {
        _playerLife = GetComponent<PlayerLife>();
    }
    public void ShowDamageFeedback (PlayerStatusData playerDamagedData)
    {      
        if (stayTransparent != null)
            StopCoroutine (stayTransparent);

        _audioSource.clip = _reciveDamageClip;
        _audioSource.Play();
        stayTransparent = StartCoroutine(StayTransparentUntil(playerDamagedData.afterHitInvulnerabilityTime));
    }

    public void ShowDeathFeedback()
    {
        ExplosionFX explosion = Instantiate(_explosion, transform.position, Quaternion.identity);

    }

    IEnumerator StayTransparentUntil (float transparencyDuration)
    {
        _playerSpriteRenderer.color = _invulnerableColor;
        yield return new WaitForSeconds(transparencyDuration);
        _playerSpriteRenderer.color = Color.white;
            
    }

    private void OnEnable()
    {
        _playerLife.PlayerDamagedAction += ShowDamageFeedback;
        _playerLife.PlayerDiedAction += ShowDeathFeedback;
    }

    private void OnDisable()
    {
        _playerLife.PlayerDamagedAction -= ShowDamageFeedback;
        _playerLife.PlayerDiedAction -= ShowDeathFeedback;
    }
}
