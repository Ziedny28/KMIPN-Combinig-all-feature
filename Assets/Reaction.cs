using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//membuat rekasi yang bisa dilakukan
[CreateAssetMenu]
public class Reaction : ScriptableObject
{
    public List<string> needed;
    public ItemData result;
}
