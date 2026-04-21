using System.Collections;
using UnityEngine;

public class PlayerDamageFeedback : MonoBehaviour
{
    [SerializeField] SpriteRenderer _playerSpriteRenderer;
    [SerializeField] Color _invulnerableColor;
    [SerializeField] GameObject _explosion;

    Coroutine stayTransparent;
    public void SetTransparent (PlayerStatusData playerDamagedData)
    {      
        if (stayTransparent != null)
            StopCoroutine (stayTransparent);

        stayTransparent = StartCoroutine(StayTransparentUntil(playerDamagedData.afterHitInvulnerabilityTime));
    }

    public void ShowDeathFeedback()
    {
        Instantiate(_explosion, transform.position, Quaternion.identity);
    }

    IEnumerator StayTransparentUntil (float transparencyDuration)
    {
        _playerSpriteRenderer.color = _invulnerableColor;
        yield return new WaitForSeconds(transparencyDuration);
        _playerSpriteRenderer.color = Color.white;
            
    }
}
