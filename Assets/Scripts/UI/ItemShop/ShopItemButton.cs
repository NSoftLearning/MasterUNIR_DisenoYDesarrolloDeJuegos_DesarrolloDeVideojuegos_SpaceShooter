using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] TMP_Text _price;
    [SerializeField] TMP_Text _name;
    
    DescriptionPanel _descriptionPanel;
    public Action<int> ShopItemButtonClicked;
    int _itemIndex;
    public void Intialize(int itemIndex, string name, int price, DescriptionPanel descriptionPanel) 
    { 
        _itemIndex = itemIndex;
        _name.text = name;
        _price.text = price.ToString();
        _descriptionPanel = descriptionPanel;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _descriptionPanel.FillPanel(_itemIndex);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _descriptionPanel.ClearPanel();
    }

    public void HandleButtonClicked()
    {
        ShopItemButtonClicked.Invoke(_itemIndex);
    }
}
