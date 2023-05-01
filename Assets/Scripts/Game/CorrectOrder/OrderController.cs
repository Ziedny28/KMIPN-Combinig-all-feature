using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderController : MonoBehaviour
{

    public int[] correctOrder = new int[] { 3, 1, 4, 2 };
    public int currentObjectIndex = 0; 
    public void ActivateObject(int objectIndex)
    {
        if (objectIndex == correctOrder[currentObjectIndex])
        {
            currentObjectIndex++;

            //Urut
            if (currentObjectIndex == correctOrder.Length)
            {
                Debug.Log("Akses berhasil!");
                currentObjectIndex = 0;
            }
        }

        //Tidak urut
        else
        {
            Debug.Log("Akses gagal!");
            currentObjectIndex = 0;
        }
    }


    public void OnObjectClicked(int objectIndex)
    {
        FindObjectOfType<OrderController>().ActivateObject(objectIndex);
    }

}
