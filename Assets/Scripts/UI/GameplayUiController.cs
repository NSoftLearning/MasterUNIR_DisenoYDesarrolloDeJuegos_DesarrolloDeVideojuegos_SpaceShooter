using UnityEngine;

public class GameplayUiController : MonoBehaviour
{
    [SerializeField] GameObject _endOfGameUI;
    [SerializeField] GameObject _levelClearedUI;
    [SerializeField] PlayerDeadUIController _playerDeadUI;
    [SerializeField] GameStatusSO _gameStatusSO;
    

    private void Start()
    {
        _playerDeadUI.Hide();
        _levelClearedUI.SetActive(false);
        _endOfGameUI.SetActive(false);
    }

    public void ShowPlayerDeadUI()
    {
        _playerDeadUI.Show();
    }

    public void ShowLevelClearedUI()
    {
        if (_gameStatusSO._currentGameLevel >= _gameStatusSO.levelsLibrary.levelsData.Count)
        {
            _endOfGameUI.SetActive(true);
            return;
        }

        _levelClearedUI.SetActive(true);
    }

}
