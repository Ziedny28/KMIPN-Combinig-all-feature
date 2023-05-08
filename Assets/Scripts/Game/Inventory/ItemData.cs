using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[CreateAssetMenu(fileName = "New ScriptableObject", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string displayName;
    public string description;
    public Sprite icon;
}
