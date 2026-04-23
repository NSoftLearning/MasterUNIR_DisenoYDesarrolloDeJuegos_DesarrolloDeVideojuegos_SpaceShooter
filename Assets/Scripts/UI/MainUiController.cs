using System.Text;
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
    [SerializeField] TMP_Text _score;
    [SerializeField] TMP_Text _currency;

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

    public void RefreshCurrency (int newScore)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("Score: ");
        stringBuilder.Append(newScore);
        _score.text = stringBuilder.ToString();
    }

    public void RefreshCash (int newCurrency)
    {
        _currency.text = newCurrency.ToString();
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
