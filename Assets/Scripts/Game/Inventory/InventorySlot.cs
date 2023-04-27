using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI label;
    public TextMeshProUGUI stackSize;

    public void ClearSlot()
    {
        icon.enabled = false;
        label.enabled = false;
        stackSize.enabled = false;
    }

    public void DrawSlot(InventoryItem item)
    {
        if (item == null)
        {
            ClearSlot();
            return;
        }

        icon.enabled = true;
        label.enabled = true;
        stackSize.enabled = true;

        icon.sprite = item.itemData.icon;
        label.text = item.itemData.displayName;
        stackSize.text = item.stackSize.ToString();


    }
}
