using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject player;
    public GameObject inventory;
    private bool inventoryEnabled;

    private GameObject[] slot;
    private int slotCount = 41;

    public GameObject slotHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if(inventoryEnabled == true)
        {
            inventory.SetActive(true);
            player.SetActive(false);
        }
        else
        {
            inventory.SetActive(false);
            player.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(item.ID, item.type, item.description, item.icon);
        }
    }

    void AddItem(int itemID, string itemType, string itemDescription, Texture2D itemIcon)
    {
        for(int i = 0; i < slotCount; i++)
        {
            
        }
    }
}
