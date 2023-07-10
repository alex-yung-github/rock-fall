using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarterIslandNPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;
    
    public int indexRevealName;
    public TextMeshProUGUI SpeakerNameText;
    public string speakerName;

    public GameObject[] otherPanelList;
    
    void Start(){
        dialoguePanel.SetActive(false);
        dialogueText.text = string.Empty;
    }
    // Update is called once per frame
    void Update()
    {

        if(playerIsClose && Input.GetKeyDown("e") && otherPanelsUnactive()){
            if(dialoguePanel.activeInHierarchy){
                dialogueText.text = string.Empty;
                StopAllCoroutines();
                NextLine();
            }
            else{
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
    }

    public bool otherPanelsUnactive(){
        for(int i = 0; i < otherPanelList.Length; i++){
            if(otherPanelList[i].activeSelf == true){
                return false;
            }
        }
        return true;
    } 

    public void zeroText(){
        dialogueText.text = string.Empty;
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing(){
        foreach (char c in dialogue[index].ToCharArray()) 
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine(){
        if(index == indexRevealName){
            SpeakerNameText.text = speakerName;
        }
        if(index < dialogue.Length - 1){
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else{
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = false;
            zeroText();
        }
    }
}
