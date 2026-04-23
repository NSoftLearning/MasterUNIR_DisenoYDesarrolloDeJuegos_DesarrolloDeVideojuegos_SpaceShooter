using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainUiController : MonoBehaviour
{
    [SerializeField] Image _redAlertWheel;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] Image _healthBarForeground;
    [SerializeField] float _redAlertTreshold = .2f;
    private void Start()
    {
        _redAlertWheel.gameObject.SetActive(false);
    }



    public void UpdateLifeBar (PlayerStatusData playerDamagedData)
    {

        float remainingHealth = (float)playerDamagedData.remainingHealth / playerDamagedData.maxHealth;
        _healthBarForeground.fillAmount = remainingHealth;
        
        if (remainingHealth < _redAlertTreshold)
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

    public void SetPlayerAsKilled()
    {
        ExitRedAlert();
        _healthBarForeground.fillAmount = 0;
    }

}
