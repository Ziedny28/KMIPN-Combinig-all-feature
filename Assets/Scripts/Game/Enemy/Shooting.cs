using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Camera mainCam;
    private Vector3 mousePos;

    //dimana bullet akan diinstantiate
    public Transform bulletTransform;

    //gameobject yang bisa jadi peluru
    public GameObject[] bulletVariants;
    private GameObject bulletVariant;
    
    private int bulletVariantCount;
    private int bulletVariantIndex=0;

    private ItemData item;
    
    private bool canFire = true;
    private float timer;

    public float timeBetweenFiring = 0.3f;
    [Tooltip("Gameobject attached to inventory")]
    public Inventory inventory;

    public static event HandleItem OnReduceItem;
    public delegate void HandleItem(ItemData itemData);

    //to detect if mouse pressed
    public bool firing;
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started) firing = true;
        if (context.performed) firing = true;
        if (context.canceled) firing = false;
    }

    public void Start()
    {
        bulletVariant = bulletVariants[0];
        bulletVariantCount = bulletVariants.Length;
        item = bulletVariant.gameObject.GetComponent<Bullet>().item;
    }

    void Update()
    {
        //changing bullet type
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bulletVariantIndex++;
            if(bulletVariantIndex >= bulletVariantCount)
            {
                bulletVariantIndex = 0;
            }
            bulletVariant = bulletVariants[bulletVariantIndex];
            item = bulletVariant.gameObject.GetComponent<Bullet>().item;
        }
        ProcessFiring();
    }

    private void ProcessFiring()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (firing && canFire)
        {

            //checking if item that used to shoot is available in inventory
            if (GetInventory().Contains(item))
            {
                Instantiate(bulletVariant, bulletTransform.position, Quaternion.identity);
                OnReduceItem?.Invoke(item);
            }
            canFire = false;
        }
    }

    private List<ItemData> GetInventory()
    {
        List<ItemData> inInventory = new List<ItemData>();
        foreach (InventoryItem i in inventory.inventory)
        {
            inInventory.Add(i.itemData);
        }
        return inInventory;
    }


}
