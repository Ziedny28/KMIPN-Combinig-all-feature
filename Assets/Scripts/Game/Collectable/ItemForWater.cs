using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemForWater : MonoBehaviour, ICollectable
{
    public static event HandleElement2Collected OnElement2Collected;
    public delegate void HandleElement2Collected(ItemData itemData);
    public ItemData element2;
    public void Collect()
    {
        Debug.Log("You Collected an element2");
        Destroy(gameObject);
        OnElement2Collected?.Invoke(element2);
    }
}

