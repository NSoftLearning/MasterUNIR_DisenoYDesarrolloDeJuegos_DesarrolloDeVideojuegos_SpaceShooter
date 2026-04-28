using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class DescriptionPanel : MonoBehaviour
{
    [SerializeField] TMP_Text _title;
    [SerializeField] TMP_Text _description;

    [SerializeField] WeaponsLIbrarySO _weaponsLibrary;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void FillPanel(int objectIndex)
    {
        gameObject.SetActive(true);
        _title.text = _weaponsLibrary.availableWeapons[objectIndex].weaponName + " x " + _weaponsLibrary.availableWeapons[objectIndex].ammo;
        _description.text = _weaponsLibrary.availableWeapons[objectIndex].description;
    }

    public void ClearPanel()
    {
        gameObject.SetActive(false);
        _title.text = "";
        _description.text = "";

    }

}
