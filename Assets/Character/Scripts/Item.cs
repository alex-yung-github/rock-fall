using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool pickedUp;
    PlayerStats playerStats;
    
    public void ItemUsage()
    {
        if(type == "reset")
        {

        }
        if(type == "Charm")
        {
            playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            switch(ID)
            {
                case 1:
                    playerStats.maxSpeed = playerStats.maxSpeed * 2;
                    Debug.Log("Item used");
                    break;
            }
        }
    }
}
