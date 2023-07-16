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

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        
    }
    void Start()
    {
        slotIconGO = transform.GetChild(0);
        empty = true;
    }
    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = icon;
    }
}
