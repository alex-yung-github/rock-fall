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
                case 3:
                    playerStats.rockCooldownAltered = true;
                    playerStats.rockCooldown = 25;
                    break;
                case 4:
                    playerStats.jumpingPowerAltered = true;
                    playerStats.jumpingPower = 48f;
                    break;
                case 5:
                    playerStats.healthAltered = true;
                    playerStats.health = 200;
                    break;
                case 6:
                    playerStats.attackAltered = true;
                    playerStats.attack = 20;
                    break;
            }
        }
    }
}
