using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isInRange; // is player in range of door?
    public KeyCode interactKey; // key for user to press
    public string interactName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                SceneManager.LoadScene(interactName); // new Scee
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("something's here?");
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("player in range");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("something left?");
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("player not in range");
        }
    }
}
