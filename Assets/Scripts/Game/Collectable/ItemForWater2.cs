using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemForWater2 : MonoBehaviour, ICollectable
{
    public static event HandleElement1Collected OnElement1Collected;
    public delegate void HandleElement1Collected(ItemData itemData);
    public ItemData element1;
    public void Collect()
    {
        Debug.Log("You Collected an element1");
        Destroy(gameObject);
        OnElement1Collected?.Invoke(element1);
    }
}
