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
                Debug.Log(slot.GetComponent<equipSlot>().empty);
                if(slot.GetComponent<equipSlot>().empty == true)
                {
                    slot.GetComponent<Image>().sprite = icon;
                    
                    item.transform.parent = slot.transform;
                    item.SetActive(false);
                    Debug.Log("assigned to slot " + slot.name);
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
