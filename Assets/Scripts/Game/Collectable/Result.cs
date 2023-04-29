using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour, ICollectable
{
    public static event HandleResultCollected OnResultCollected;
    public delegate void HandleResultCollected(ItemData itemData);
    public ItemData ResultData;
    public void Collect()
    {
        Debug.Log("You Collected a Result");
        Destroy(gameObject);
        OnResultCollected?.Invoke(ResultData);
    }
}
