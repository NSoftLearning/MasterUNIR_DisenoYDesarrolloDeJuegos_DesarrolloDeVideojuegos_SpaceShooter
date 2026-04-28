using UnityEngine;
using UnityEngine.UI;

public class ShopWeaponSlot : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] GameObject _clearButton;



    private void Start()    
    {
        _image.gameObject.SetActive(false);
        _clearButton.SetActive(false);
    }
    public void SetItem ( Sprite sprite)
    {
        _image.sprite = sprite;
        _clearButton.SetActive(true);
        _image.gameObject.SetActive(true);
    }
    public void ClearUI()
    {
        _image.gameObject.SetActive(false);
        _clearButton.SetActive(false);
    }
}
