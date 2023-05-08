using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName="New ScriptableObject",menuName="Scriptable Objects/NPCData")]
public class NPCData : ScriptableObject
{
    public string npcName;
    public Sprite NpcPicture;
}
