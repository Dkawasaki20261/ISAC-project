using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HotBarIcon : MonoBehaviour
{
    public OwnInventory owninventory;
    public Image icon;
    public TextMeshProUGUI number;
    public int myIndex;
    public void UpdateIcon()
    {
        if(owninventory.CheckExistItem(myIndex) == true)
        {
            var data = owninventory.GetItem(myIndex);
            icon.sprite = data.Data.icon;
            number.text = data.NumOfItem.ToString();
        }
        else
        {
            icon.sprite = null;
            number.text = string.Empty;
        }
    }
    private void Update()
    {
        UpdateIcon();
    }
}
