using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CraftButton : MonoBehaviour
{
    public Button craftButton;
    public TextMeshProUGUI craftText;

    public void ChangeText(string result)
    {
        craftText.text = $"reaksikan {result}";
    }
}
