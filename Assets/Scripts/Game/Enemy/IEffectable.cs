using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IEffectable : MonoBehaviour
{
    public Enemy enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("colliding");

        //checking if gameobject that colliding giving effect
        Effecting effecting = collision.GetComponent<Effecting>();
        if (effecting != null)
        {
            GetDamage(effecting.Effect());
        }
    }


    void GetDamage(Dictionary<Element,int> effect)
    {
        //getting element as damageElement and damage
        Element damageElement = effect.First().Key;
        int damage = effect.First().Value;
        Debug.Log($"damage sebesar{damage}");

        //if enemy's weakness is equals to damageElement's element
        if (damageElement == enemy.weakness)
        {
           enemy.health -= damage;
        }
        else
        {
            enemy.health -= damage/2;
        }

        if(enemy.health < 0)
        {
            Debug.Log("Destroyed");
            Destroy(gameObject);
        }
    }
}
