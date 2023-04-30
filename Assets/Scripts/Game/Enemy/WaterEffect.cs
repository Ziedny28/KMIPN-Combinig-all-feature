using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffect : MonoBehaviour, Effecting
{
    [SerializeField] Element element;
    [SerializeField] int damage;

    //this function will attached to an item that become weapon
   public Dictionary<Element, int> Effect()
    {
        //it will return dictionary that said damage elemt:damage
        Dictionary<Element, int> effect = new Dictionary<Element, int>();
        effect.Add(element, damage);
        return effect;
    }
}
