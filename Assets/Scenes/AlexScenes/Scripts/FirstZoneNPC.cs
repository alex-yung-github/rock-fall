using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstZoneIslandNPC : MonoBehaviour
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

    private bool postBoss1Stated = false;
    private bool playerBeatFirstBoss = false;
    public string[] postBossDialogue1;
    public string[] postBossDialogue2;
    public BossProgressCheck playerBossChecker;
    public GameObject portalSpawner;

    
    void Start(){
        dialoguePanel.SetActive(false);
        dialogueText.text = string.Empty;
        if(playerBossChecker.getFZIslandBoss()){
            playerBeatFirstBoss = true;
        }
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

        if(portalSpawner == null && playerBeatFirstBoss){
            portalSpawner.SetActive(true);
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

    public void zeroText(){
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        StopAllCoroutines();
    }

    IEnumerator Typing(){
        if(playerBeatFirstBoss && postBoss1Stated == false){
            if(index == postBossDialogue1.Length){
                postBoss1Stated = true;
                zeroText();
            }
            else{
                foreach (char c in postBossDialogue1[index].ToCharArray()) 
                {
                    dialogueText.text += c;
                    yield return new WaitForSeconds(wordSpeed);
                }
            }
        }
        else if(playerBeatFirstBoss){
            foreach (char c in postBossDialogue2[index].ToCharArray()) 
            {
                dialogueText.text += c;
                yield return new WaitForSeconds(wordSpeed);
            }
        }
        else{
            foreach (char c in dialogue[index].ToCharArray()) 
            {
                dialogueText.text += c;
                yield return new WaitForSeconds(wordSpeed);
            }
        }
        
    }

    public void NextLine(){
        if(index == indexRevealName){
            SpeakerNameText.text = speakerName;
        }
        if(index < dialogue.Length){
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
            if(playerBossChecker.getFZIslandBoss()){
                playerBeatFirstBoss = true;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = false;
            zeroText();
        }
    }
}
