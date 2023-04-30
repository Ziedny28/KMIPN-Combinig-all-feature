using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemy : ScriptableObject
{
    public string enemyName;
    public Element elementType;
    public Element weakness;
    public int health;
}
