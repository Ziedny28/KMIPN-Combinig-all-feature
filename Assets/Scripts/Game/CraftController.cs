using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CraftController : MonoBehaviour
{

    //masih untuk simulasi mengurangi data
    public static event HandleReduceItem OnReduceItem;
    public delegate void HandleReduceItem(ItemData itemData);

    public ItemData itemData;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            ReduceItem();
        }
    }

    private void ReduceItem()
    {
        Debug.Log($"Mengurangi {itemData.name} dengan 1");
        OnReduceItem?.Invoke(itemData);
    }
}
