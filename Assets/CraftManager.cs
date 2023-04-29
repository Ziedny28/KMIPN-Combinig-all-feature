using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    [Tooltip("Scriptable object reaction")]
    public List<Reaction> reactions;
    [Tooltip("Gameobject attached to inventory")]
    public Inventory inventory;

    //untuk mengurangi data
    public static event HandleReduceItem OnReduceItem;
    public static event HandleReduceItem OnAddItem;
    public delegate void HandleReduceItem(ItemData itemData);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CheckReactables();
        }
    }

    private void CheckReactables()
    {
        //getting data of what currently in player's inventory in dictionary
        Dictionary<string, int> inInventory = GetInventory();

        //checking if the inventory contains the items needed
        foreach (Reaction r in reactions)
        {
            //checking each needed stuff
            List<bool> allResourceAvailable = new List<bool>();

            foreach (ItemData needed in r.needed)
            {
                string neededKey = needed.displayName;
                allResourceAvailable.Add(inInventory.ContainsKey(neededKey));
            }

            //if a stuff doesnt available, the reaction shouldnt be possible
            if (allResourceAvailable.Contains(false))
            {
                Debug.Log($"the reaction {r.result.name} not possible");
            }
            else
            {
                Debug.Log($"the reaction {r.result.name} possible");
                Reacting(r);
            }
        }
    }

    private void Reacting(Reaction r)
    {
        Debug.Log($"reaksi {r.result.displayName} dimulai");
        //mengurangi data yang diperlukan
        foreach (ItemData i in r.needed) 
        {
            Debug.Log($"Mengurangi {i.name} dengan 1");
            OnReduceItem?.Invoke(i);
        }

        //memberi player hasil
        OnAddItem?.Invoke(r.result);
        Debug.Log($"You Got{r.result.displayName}");
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
