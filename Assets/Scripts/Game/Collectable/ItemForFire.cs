using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemForFire : MonoBehaviour, ICollectable
{
    //ini lbh rapi, dinamis, general, jd bisa dipakai lbh banyak kali tanpa banyak ngubah2
    public static event HandleItemCollected OnItemCollected;
    public delegate void HandleItemCollected(ItemData itemData);
    public ItemData itemData;
    public void Collect()
    {
        Debug.Log($"You Collected an {itemData.displayName}");
        Destroy(gameObject);
        OnItemCollected?.Invoke(itemData);
    }
}
