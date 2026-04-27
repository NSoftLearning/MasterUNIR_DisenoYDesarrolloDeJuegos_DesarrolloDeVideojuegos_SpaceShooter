using UnityEngine;

public class GameplayUiController : MonoBehaviour
{


    [SerializeField] GameObject _playerDeadUI;

    private void Start()
    {
        _playerDeadUI.SetActive(false);
    }

    public void ShowPlayerDeadUI()
    {
        _playerDeadUI.SetActive(true);
    }

    private void OnEnable()
    {
        
    }

}
