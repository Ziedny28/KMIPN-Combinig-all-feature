using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ScriptableObject", menuName = "Scriptable Objects/EnemyData")]
public class Enemy : ScriptableObject
{
    public string enemyName;
    public Element elementType;
    public Element weakness;
    public int health;
}
