using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableActivation : MonoBehaviour
{
    
    public GameObject keyNotification;

    void Start(){
        keyNotification.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Interactable"){
            keyNotification.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Interactable"){
            keyNotification.SetActive(false);
        }
    }


}
