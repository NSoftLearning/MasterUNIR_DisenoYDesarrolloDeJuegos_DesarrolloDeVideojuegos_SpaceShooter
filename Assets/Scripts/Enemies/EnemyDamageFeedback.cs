using System.Collections;
using UnityEngine;

public class EnemyDamageFeedback : MonoBehaviour
{
    [SerializeField] SpriteRenderer _enemySpriteRenderer;
    [SerializeField] Color _normalColor = Color.white;
    [SerializeField] Color _damageColor = Color.red;
    [SerializeField] float _colorChangeDuration = 1;
    [SerializeField] float _inDamagedColorDuration = .2f;
    [SerializeField] GameObject _destroyedFX;


    Coroutine colorChangeCorroutine;
    float effectStartTime;
    float effectEndTime;
    public void ShowDamageFeedback()
    {
        if (colorChangeCorroutine != null)
            StopCoroutine(colorChangeCorroutine);

        _enemySpriteRenderer.color = _damageColor;
        effectStartTime = Time.time;
        effectEndTime = Time.time + _colorChangeDuration + _inDamagedColorDuration;
        colorChangeCorroutine = StartCoroutine(BackToNormalColor());

    }

    public void ShowDestroyedFeedback()
    {
        Instantiate(_destroyedFX, transform.position, Quaternion.identity);       
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


}
