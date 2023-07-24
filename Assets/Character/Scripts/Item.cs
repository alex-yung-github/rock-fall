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
        if(type == "Charm")
        {
            playerStats = GameObject.FindGameObjectWithTag("Inventory").GetComponent<PlayerStats>();
            switch(ID)
            {
                case 1:
                    playerStats.speedAltered = true;
                    playerStats.maxSpeed = 30;
                    break;
                case 2:
                    playerStats.recoilAltered = true;
                    playerStats.recoilForce = 32;
                    break;
            }
        }
    }
}
