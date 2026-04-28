using UnityEngine;

public class GameplayUiController : MonoBehaviour
{
    [SerializeField] UIWithScore _endOfGameUI;
    [SerializeField] GameObject _levelClearedUI;
    [SerializeField] UIWithScore _playerDeadUI;
    [SerializeField] GameStatusSO _gameStatusSO;
    [SerializeField] public WeaponDeployerUI topWeaponDeployerUI;
    [SerializeField] public WeaponDeployerUI bottomWeaponDeployerUI;
    

    private void Start()
    {
        _playerDeadUI.Hide();
        _levelClearedUI.SetActive(false);
        _endOfGameUI.Hide();

        topWeaponDeployerUI.Setup(
            ComponentLocatorService.Components.GameStatus.topSlotWeaponIndex, 
            ComponentLocatorService.Components.GameStatus.topSlotWeaponSet);

        bottomWeaponDeployerUI.Setup(
            ComponentLocatorService.Components.GameStatus.bottomSlotWeaponIndex,
            ComponentLocatorService.Components.GameStatus.bottomSlotWeaponSet);
    }



    public void SetupTopWeaponDeployerUI (int  indexInLibrary)
    {

    }
    public void SetupBottomWeaponDeployerUI(int indexInLibrary)
    {

    }
    public void ShowPlayerDeadUI()
    {
        _playerDeadUI.Show();
    }

    public void ShowLevelClearedUI()
    {
        if (_gameStatusSO._currentGameLevel >= _gameStatusSO.levelsLibrary.levelsData.Count)
        {
            _endOfGameUI.Show();
            return;
        }

        _levelClearedUI.SetActive(true);
    }

}
