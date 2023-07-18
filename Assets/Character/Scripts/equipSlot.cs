using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class equipSlot : MonoBehaviour, IPointerClickHandler
{
    public GameObject item;
    public GameObject placeholder;
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool empty;
    public bool active;

    public Transform slotIconGO;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        empty = true;
        item = placeholder;
        ID = 0;
        type = "reset";
        description = "Resets Buffs";
        icon = null;
        UpdateSlot();
    }
    void Start()
    {
        slotIconGO = transform.GetChild(0);
        empty = true;
        active = false;
    }

    void Update()
    {
        if(!empty && !active)
        {
            active = true;
            item.GetComponent<Item>().ItemUsage();
        }
        if(empty && active)
        {
            active = false;
            item.GetComponent<Item>().ItemUsage();
        }
    }

    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = icon;
    }
}
