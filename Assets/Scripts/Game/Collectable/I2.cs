using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I2 : MonoBehaviour, ICollectable
{
    public static event HandleI2ollected OnI2Collected;
    public delegate void HandleI2ollected(ItemData itemData);
    public ItemData I2Data;
    public void Collect()
    {
        Debug.Log("You Collected an I2");
        Destroy(gameObject);
        OnI2Collected?.Invoke(I2Data);
    }
}
