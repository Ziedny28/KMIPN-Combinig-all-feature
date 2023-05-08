using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeringArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<AreaTriggerable>() != null)
        {
            AreaTriggerable areaTriggerable = collision.gameObject.GetComponent<AreaTriggerable>();
            areaTriggerable.EnterArea();
        }
    }
}
