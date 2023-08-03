using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public GameObject player;
    public GameObject inventory;
    [HideInInspector] public bool inventoryEnabled;

    private GameObject[] slot;
    private int slotCount;

    public GameObject slotHolder;
    // Start is called before the first frame update
    public GameObject startingItem;
    public GameObject startingItem2;
    
    void Start()
    {
        slotCount = 72;
        slot = new GameObject[slotCount];
        for(int i = 0; i < slotCount; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            
            if(slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
        if(startingItem)
        {
            Item item = startingItem.GetComponent<Item>();
            Item item2 = startingItem2.GetComponent<Item>();
            AddItem(startingItem, item.ID, item.type, item.description, item.icon);
            AddItem(startingItem2, item2.ID, item2.type, item2.description, item2.icon);
        }
        
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
        }
        else
        {
            inventory.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
        }
    }

    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for(int i = 0; i < slotCount; i++)
        {
            if(slot[i].GetComponent<Slot>().empty)
            {
                GameObject myItem = Instantiate(itemObject, new Vector3(0, 0, 0), Quaternion.identity);
                myItem.GetComponent<Item>().pickedUp = true;
                slot[i].GetComponent<Slot>().item = myItem;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().description = itemDescription;

                myItem.transform.parent = slot[i].transform;
                myItem.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;

                return;
            }
        }
    }
}
