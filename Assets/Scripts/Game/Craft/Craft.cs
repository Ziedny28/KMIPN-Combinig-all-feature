using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    public Inventory inventory;

    private void Update()
    {
        //how to get data of all item.
        if (Input.GetKeyDown(KeyCode.E))
        {
            string res = "";
            foreach(InventoryItem i in inventory.inventory)
            {
                res += $"nama:{i.itemData.name},jumlah:{i.stackSize}\n";
            }
            Debug.Log(res);
        }
    }
}
