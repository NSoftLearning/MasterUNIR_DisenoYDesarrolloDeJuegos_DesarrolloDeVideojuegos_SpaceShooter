using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainUiController : MonoBehaviour
{
    [SerializeField] Sprite[] _lifeBar;
    [SerializeField] Image _healthBarImge;
    [SerializeField] Image _redAlertWheel;
    [SerializeField] AudioSource _audioSource;
    private void Start()
    {
        _redAlertWheel.gameObject.SetActive(false);
    }



    public void UpdateLifeBar (PlayerStatusData playerDamagedData)
    {
        float barIndex = ((float)playerDamagedData.remainingHealth / playerDamagedData.maxHealth) * (_lifeBar.Length - 1);

        Debug.Log("bar index " + barIndex);
        _healthBarImge.sprite = _lifeBar[(int)barIndex];
        if (barIndex < .5f)
        {
            EnterRedAlert();
        }else
        {
            ExitRedAlert();
        }
    }

    void EnterRedAlert()
    {
        _redAlertWheel.gameObject.SetActive(true);
        _audioSource.Play();
    }
    public void ExitRedAlert ()
    {
        _redAlertWheel.gameObject.SetActive(false);
        _audioSource.Stop();
    }

}
