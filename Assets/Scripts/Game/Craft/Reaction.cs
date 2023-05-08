using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//membuat rekasi yang bisa dilakukan
[CreateAssetMenu(fileName = "New ScriptableObject", menuName = "Scriptable Objects/ReactionData")]
public class Reaction : ScriptableObject
{
    public List<ItemData> needed;
    public ItemData result;
}
