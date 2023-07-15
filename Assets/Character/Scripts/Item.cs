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
    PlayerMovement playerMovement;
    
    public void ItemUsage()
    {
        if(type == "Charm")
        {
            playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            switch(ID)
            {
                case 0:
                    playerMovement.maxSpeed = 50;
                    break;
            }
        }
    }
}
