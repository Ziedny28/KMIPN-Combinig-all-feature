using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class CraftUi : MonoBehaviour
{
    public GameObject craftButtonPrefab;
    public CraftManager craftManager;

    private void OnEnable()
    {
        CraftManager.OnReactable += CreateButton;
        CraftManager.closeReactingUI += DestroyButton;
    }

    private void OnDisable()
    {
        CraftManager.OnReactable -= CreateButton;
        CraftManager.closeReactingUI -= DestroyButton;
    }

    void CreateButton(Reaction r)
    {
        //creating craft button and make it a child of this object
        GameObject newCraftButton = Instantiate(craftButtonPrefab);
        newCraftButton.transform.SetParent(transform, false);

        //changing text
        newCraftButton.GetComponent<CraftButton>().ChangeText(r.result.displayName);

        //creating craft/reacting event
        newCraftButton.GetComponent<Button>().onClick.AddListener(delegate { craftManager.Reacting(r); });
    }


    void DestroyButton()
    {
        Debug.Log(transform.childCount);
        int i = 0;

        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[transform.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        //Now destroy them
        foreach (GameObject child in allChildren)
        {
            child.gameObject.SetActive(false);
            DestroyImmediate(child.gameObject);
        }

        Debug.Log(transform.childCount);
    }
}
