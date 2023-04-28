using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    public List<Reaction> reactions;
    public Inventory inventory;

    private void Update()
    {
        //if player clik tab, crafting log will show
        if (Input.GetKeyDown(KeyCode.V))
        {
            //getting data of what currently in player's inventory
            Dictionary<string, int> inInventory = GetInventory();
            string ininventory = "";
            foreach (var i in inInventory)
            {
                ininventory += $"Key: {i.Key}, \tValue:{i.Value}\n";
            }
            Debug.Log(ininventory);

            String reaction="";
            foreach(Reaction r in reactions)
            {
                reaction += $"{r.needed}";
            }
            Debug.Log(reaction);

        }
    }

    private Dictionary<string, int> GetInventory()
    {
        Dictionary<string, int> inInventory = new Dictionary<string, int>();
        foreach(InventoryItem i in inventory.inventory) 
        {
            inInventory.Add(i.itemData.name, i.stackSize);
        }
        return inInventory;
    }
}
