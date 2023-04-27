using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PVP;

public class PVP : MonoBehaviour, ICollectable
{
    public static event HandlePVPCollected OnPVPCollected;
    public delegate void HandlePVPCollected(ItemData itemData);
    public ItemData PVPData;
    public void Collect()
    {
        Debug.Log("You Collected a PVP");
        Destroy(gameObject);
        OnPVPCollected?.Invoke(PVPData);
    }
}
