using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    public bool playerIsClose;
    public GameObject shopPanel;
    public GameObject player;
    public GameObject[] otherPanelList;
    private bool activated = false;

    // Update is called once per frame
    void Update()
    {
        if(playerIsClose && Input.GetKeyDown("e") && otherPanelsUnactive() && player.GetComponent<PlayerMovement>().shopOpen == false)
        {
            shopPanel.SetActive(true);
            activated = true;
            player.GetComponent<PlayerMovement>().shopOpen = true;
            player.GetComponent<RockShot>().canFire = false;
        }
        else if (activated && Input.GetKeyDown("e") && shopPanel.activeInHierarchy) {
            shopPanel.SetActive(false);
            player.GetComponent<PlayerMovement>().shopOpen = false;
            player.GetComponent<RockShot>().canFire = true;
        }
    }

    public bool otherPanelsUnactive(){
        if(otherPanelList == null){
            return true;
        }
        for(int i = 0; i < otherPanelList.Length; i++){
            if(otherPanelList[i].activeSelf == true){
                return false;
            }
        }
        return true;
    } 


    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = false;
        }
    }
}
