using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static event Action<List<InventoryItem>> OnInventoryChange;

    public List<InventoryItem> inventory = new List<InventoryItem>();
    private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();

    private void OnEnable()
    {
        //subscribing to onstuff collected
        //so the item now is listed in inventory

        //adding
        PVP.OnPVPCollected += Add;
        I2.OnI2Collected+= Add;
        ItemForWater2.OnElement1Collected += Add;
        ItemForWater.OnElement2Collected += Add;
        Result.OnResultCollected += Add;
        CraftManager.OnAddItem += Add;
        Result2.OnResult2Collected+= Add;

        //dynamic
        ItemForFire.OnItemCollected+= Add;
        ItemForFire2.OnItemCollected += Add;

        //reduce
        CraftManager.OnReduceItem += Remove;
        Shooting.OnReduceItem += Remove;
        
    }

    private void OnDisable()
    {
        //unsubscribing to onstuff collected

        //adding
        PVP.OnPVPCollected -= Add;
        I2.OnI2Collected -= Add;
        ItemForWater.OnElement2Collected -= Add;
        ItemForWater2.OnElement1Collected -= Add;
        Result.OnResultCollected -= Add;
        CraftManager.OnAddItem -= Add;
        Result2.OnResult2Collected-= Add;

        //dynamic
        ItemForFire.OnItemCollected-= Add;
        ItemForFire2.OnItemCollected -= Add;

        //reduce

        CraftManager.OnReduceItem -= Remove;
        Shooting.OnReduceItem -= Remove;
    }

    public void Add(ItemData itemData)
    {
        if(itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.AddToStack();
            Debug.Log($"{item.itemData.displayName} total stack is now {item.stackSize}");

            OnInventoryChange?.Invoke(inventory);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            Debug.Log($"Added {itemData.displayName} to the inventory for the first time");

            OnInventoryChange?.Invoke(inventory);
        }
    }

    public void Remove(ItemData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveFromStack();
            if(item.stackSize == 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
            }

            OnInventoryChange?.Invoke(inventory);
        }
    }
}
