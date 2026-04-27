using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GlobalAmbientController _globalAmbientController;

    public void FadeToGampelayLevel ()
    {
        _globalAmbientController.RequestLevelChange("GameplayScene");
    }
}
