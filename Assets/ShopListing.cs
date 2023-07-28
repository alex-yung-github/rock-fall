using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ShopListing : MonoBehaviour
{
    public GameObject itemObject;
    private Item item;
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text type;
    [SerializeField] private TMP_Text price;
    [SerializeField] private Button button;
    [SerializeField] private Image image;

    private Inventory inventory;

    void Start()
    {
        item = itemObject.GetComponent<Item>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();

        title.text = item.title;
        type.text = item.type;
        description.text = item.description;
        price.text = item.price;
        image.sprite = item.icon;

        Button buy = button.GetComponent<Button>();
        buy.onClick.AddListener(AddToInventory);

    }

    void AddToInventory()
    {
        inventory.AddItem(itemObject, item.ID, item.type, item.description, item.icon);
    }
}
