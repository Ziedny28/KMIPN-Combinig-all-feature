using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result2 : MonoBehaviour, ICollectable
{
    public static event HandleResult2Collected OnResult2Collected;
    public delegate void HandleResult2Collected(ItemData itemData);
    public ItemData Result2Data;
    public void Collect()
    {
        Debug.Log("You Collected a Result");
        Destroy(gameObject);
        OnResult2Collected?.Invoke(Result2Data);
    }
}
