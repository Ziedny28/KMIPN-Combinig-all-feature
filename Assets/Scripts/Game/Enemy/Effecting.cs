using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Effecting
{
    //it will return dictionary that said damage elemt:damage
    public Dictionary<Element,int> Effect();
}
