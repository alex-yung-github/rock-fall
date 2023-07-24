using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class equipSlot : MonoBehaviour, IPointerClickHandler
{
    public GameObject item;
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool empty;

    public Transform slotIconGO;

    [SerializeField] PlayerStats playerStats;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        switch(ID)
            {
                case 1:
                    playerStats.speedAltered = false;
                    break;
                case 2:
                    playerStats.recoilAltered = false;
                    break;
            }

        empty = true;
        item = null;
        ID = 0;
        type = "";
        description = "";
        icon = null;
        UpdateSlot();
    }
    void Start()
    {
        slotIconGO = transform.GetChild(0);
        empty = true;
    }

    void Update()
    {
        if(!empty)
        {
            item.GetComponent<Item>().ItemUsage();
        }
    }

    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = icon;
    }
}
