using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GlobalAmbientController _globalAmbientController;
    [SerializeField] GameObject _mainMenu;
    [SerializeField] GameObject _settingsMenu;


    private void Start()
    {
        GoToMain();
    }
    public void GoToMain ()
    {
        _mainMenu.SetActive(true);
        _settingsMenu.SetActive(false);
    }


    public void GoToSettings ()
    {
        _mainMenu.SetActive(false);
        _settingsMenu.SetActive(true);
    }
    public void FadeToGampelayLevel ()
    {
        _globalAmbientController.RequestLevelChange("GameplayScene");
    }


}
