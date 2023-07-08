using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<Loot> lootList = new List<Loot>();

    Loot GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<Loot> possibleItems = new List<LootBag>();
        foreach (LootBag item in lootList)
        {
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
                
            }
            if(possibleItems.Count > 0)
            {
                LootBag droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
                return droppedItem;
            }
            Debug.Log("No Loot Dropped");
            return null;
        }
    }
    // Update is called once per frame
    public void InstantiateLoot(Vector3 spawnPosition)
    {
        LootBag droppedItem = GetDroppedItem();
        if(droppedItem != null) 
        {
            GameObject lootGameObject = InstantiateLoot(droppedItemPrefab spawnPosition, Quaternion.identity)
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite



        }
    }
}
