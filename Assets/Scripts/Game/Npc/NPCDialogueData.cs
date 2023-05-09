using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ScriptableObject", menuName = "Scriptable Objects/NPCDialogueData")]
public class NPCDialogueData : ScriptableObject
{
    //track who's talking
    public NPCData[] npcData;
    public string[] dialogue;
}
