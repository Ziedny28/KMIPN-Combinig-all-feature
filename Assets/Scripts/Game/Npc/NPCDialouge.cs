using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialouge : MonoBehaviour
{
    
    public GameObject dialougePanel;
    public TextMeshProUGUI dialogueText;

    public TextMeshProUGUI NpcName;

    

    //make dictionary character:dialouge, ganti data ui tiap dialog
    //harus urut
    public NPCData[] npcDatas;
    public string[] dialogue;

    private int index=0;

    public GameObject continueButton;
    public float wordSpeed=0.06f;
    public bool playerIsCloose;

    private void Start()
    {
        dialogueText.text = "";        
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && playerIsCloose) 
        {
            if(dialougePanel.activeInHierarchy)
            {
                ResetText();
            }
            else
            {
                dialougePanel.SetActive(true);
                UpdateUI(index);
                StartCoroutine(Typing());
            }
        }
        if(dialogueText.text == dialogue[index])
        {
            continueButton.SetActive(true);
        }
    }

    public void ResetText()
    {
        dialogueText.text = "";
        index= 0;
        dialougePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }



    public void NextLine()
    {
        continueButton.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;

            UpdateUI(index);

            dialogueText.text = ""; 
            StartCoroutine(Typing());
        }
        else
        {
            ResetText();
        }
    }

    private void UpdateUI(int idx)
    {
        NpcName.text = npcDatas[idx].npcName + " :";
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsCloose= true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsCloose = false;
            ResetText();
        }
    }
}
