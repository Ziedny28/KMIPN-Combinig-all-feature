using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Camera mainCam;
    private Vector3 mousePos;
    //make it array, so its dynamic
    public GameObject bullet;
    public ItemData item;
    public Transform bulletTransform;
    public bool canFire = true;
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

    void Update()
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
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
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
