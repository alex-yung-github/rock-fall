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
        if(playerIsClose && Input.GetKeyDown("e") && otherPanelsUnactive()){
            shopPanel.SetActive(true);
            player.SetActive(false);
            activated = true;
        }
        else if(activated && Input.GetKeyDown("e") && shopPanel.activeInHierarchy){
            shopPanel.SetActive(false);
            player.SetActive(true);  
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
