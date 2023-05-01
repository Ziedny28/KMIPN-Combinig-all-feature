using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    [Tooltip("Insert Scriptable object reaction here")]
    public List<Reaction> reactions;
    [Tooltip("Insert Gameobject attached to inventory here")]
    public Inventory inventory;

    //untuk mengurangi data, terhubung dengan script inventory
    public static event HandleItem OnReduceItem;
    public static event HandleItem OnAddItem;
    public delegate void HandleItem(ItemData itemData);

    //menghandle reaksi, terhubung dengan script craftUi
    public static event HandleReactable OnReactable;
    public delegate void HandleReactable(Reaction reaction);

    //menghandle ketika reacting ui ditutup, terhubung dengan  script craftUi
    public static event Action closeReactingUI;

    bool isOpeningReactingTab = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpeningReactingTab = !isOpeningReactingTab;
            //checking if player alredy opening reacting tab
            if (isOpeningReactingTab)
            {
                //pause
                Time.timeScale = 0;
                ProcessReacting();
            }
            if (!isOpeningReactingTab)
            {
                //resume
                Time.timeScale = 1;
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
        Dictionary<ItemData, int> inInventory = GetInventory();

        //checking if the inventory contains the items needed
        foreach (Reaction r in reactions)
        {
            bool resourceAvailable = CheckNeededResource(r,inInventory);

            //if a stuff doesnt available, the reaction shouldnt be possible
            if (!resourceAvailable)
            {
                Debug.Log($"the reaction {r.result.name} not possible");
            }
            //if it's possible
            if(resourceAvailable)
            {
                Debug.Log($"the reaction {r.result.name} possible");
                OnReactable?.Invoke(r);
            }
        }
    }

    public bool CheckNeededResource(Reaction r, Dictionary<ItemData, int> inInventory)
    {
        List<bool> allResourceAvailable = new List<bool>();

        foreach (ItemData needed in r.needed)
        {
            allResourceAvailable.Add(inInventory.ContainsKey(needed));
        }

        bool available = !allResourceAvailable.Contains(false);

        return available;
    }

    public Dictionary<ItemData, int> GetInventory()
    {
        Dictionary<ItemData, int> inInventory = new Dictionary<ItemData, int>();
        foreach(InventoryItem i in inventory.inventory) 
        {
            inInventory.Add(i.itemData, i.stackSize);
        }
        return inInventory;
    }

    // dibuat static agar bisa digunakan dari script craft ui
    public void Reacting(Reaction r)
    {
        bool resourceAvailable = CheckNeededResource(r, GetInventory());

        if (resourceAvailable)
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
        if (!resourceAvailable)
        {
            Debug.Log($"resources not available for {r.result.displayName}");
        }
       
    }
}
