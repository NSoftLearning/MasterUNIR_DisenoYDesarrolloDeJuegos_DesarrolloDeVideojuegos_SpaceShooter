using UnityEngine;

public class GameplayUiController : MonoBehaviour
{
    [SerializeField] GameObject _endOfGameUI;
    [SerializeField] GameObject _levelClearedUI;
    [SerializeField] PlayerDeadUIController _playerDeadUI;
    [SerializeField] GameStatusSO _gameStatusSO;
    [SerializeField] public WeaponDeployerUI topWeaponDeployerUI;
    [SerializeField] public WeaponDeployerUI bottomWeaponDeployerUI;
    

    private void Start()
    {
        _playerDeadUI.Hide();
        _levelClearedUI.SetActive(false);
        _endOfGameUI.SetActive(false);

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
            _endOfGameUI.SetActive(true);
            return;
        }

        _levelClearedUI.SetActive(true);
    }

}
