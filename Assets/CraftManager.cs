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
            CheckReactables();
        }
    }

    private void CheckReactables()
    {
        //getting data of what currently in player's inventory
        Dictionary<string, int> inInventory = GetInventory();

        //checking if the inventory contains the items needed
        foreach (Reaction r in reactions)
        {
            //checking each needed stuff
            List<bool> allResourceAvailable = new List<bool>();

            foreach (string needed in r.needed)
            {
                Debug.Log(needed + inInventory.ContainsKey(needed));
                allResourceAvailable.Add(inInventory.ContainsKey(needed));
            }

            //if a stuff doesnt available, the reaction shouldnt be possible
            if (allResourceAvailable.Contains(false))
            {
                Debug.Log($"the reaction {r.result.name} not possible");
            }
            else
            {
                Debug.Log($"the reaction {r.result.name} possible");
            }
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
