using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGasAlert : MonoBehaviour,AreaTriggerable
{
    public void EnterArea()
    {
        Debug.Log("Gas Bocor");

    }
}
