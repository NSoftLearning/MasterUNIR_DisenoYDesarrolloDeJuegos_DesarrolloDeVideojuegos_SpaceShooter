using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class WeaponDeployerUI : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] Image _overlay;
    [SerializeField] WeaponsLIbrarySO _weaponsLibrary;


    public void Setup (int index, bool isActive)
    {
        if (!isActive)
        {
            gameObject.SetActive(false);
            return;
        }

        _overlay.fillAmount = 0;
        _image.sprite = ComponentLocatorService.Components.WeaponsLibrary.availableWeapons[index].icon;
       // _overlay.sprite = ComponentLocatorService.Components.WeaponsLibrary.availableWeapons[index].icon;
    }
    public void RefreshOveralyFillAmout (float fillAmount)
    {      
        _overlay.fillAmount = 1 - fillAmount;
    }

}
