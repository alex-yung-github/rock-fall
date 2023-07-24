using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public GameObject item;
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool empty;
    private GameObject[] equipSlots;

    public Transform slotIconGO;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if(type == "Charm")
        {
            equipSlots = GameObject.FindGameObjectsWithTag("equipSlot");

            foreach(GameObject slot in equipSlots)
            {
                if(slot.GetComponent<equipSlot>().ID == ID)
                {
                    Debug.Log("Item already equipped");
                    return;
                }
            }
            
            foreach(GameObject slot in equipSlots)
            {
                //Debug.Log(slot.GetComponent<equipSlot>().empty);
                if(slot.GetComponent<equipSlot>().empty == true)
                {
                    item.transform.parent = slot.transform;

                    slot.GetComponent<equipSlot>().item = item;
                    slot.GetComponent<equipSlot>().icon = icon;
                    slot.GetComponent<equipSlot>().type = type;
                    slot.GetComponent<equipSlot>().ID = ID;
                    slot.GetComponent<equipSlot>().description = description;

                    //Debug.Log("assigned to slot " + slot.name);

                    slot.GetComponent<equipSlot>().UpdateSlot();
                    slot.GetComponent<equipSlot>().empty = false;
                    break;
                }
            }
        }
        //UseItem();
    }
    private void Start()
    {
        slotIconGO = transform.GetChild(0);
    }

    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = icon;
    }

    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();
    }
}
