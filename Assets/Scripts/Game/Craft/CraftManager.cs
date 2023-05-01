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
    public static event HandleItem OnReduceItem;
    public static event HandleItem OnAddItem;
    public delegate void HandleItem(ItemData itemData);

    public static event HandleReactable OnReactable;
    public delegate void HandleReactable(Reaction reaction);

    
    public static event Action closeReactingUI;


    bool isOpeningReacting = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpeningReacting = !isOpeningReacting;
            //checking if player alredy opening reacting tab
            if (isOpeningReacting)
            {
                //Time.timeScale = 0;
                ProcessReacting();
            }
            if (!isOpeningReacting)
            {
                //Time.timeScale = 1;
                CloseReactableUI();
            }
            
        }
    }

    private void CloseReactableUI()
    {
        closeReactingUI?.Invoke();
    }

    private void ProcessReacting()
    {
        //freeze player's movement

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
            //if it's possible
            else
            {
                Debug.Log($"the reaction {r.result.name} possible");
                OnReactable?.Invoke(r);
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

    // dibuat static agar bisa digunakan dari script craft ui
    public static void Reacting(Reaction r)
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
}
