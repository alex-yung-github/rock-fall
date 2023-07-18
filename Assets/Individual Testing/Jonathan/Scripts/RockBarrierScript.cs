using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBarrierScript : MonoBehaviour
{
    public GameObject swirl;
    public GameObject magicRock;
    public GameObject barrier;
    public bool isInRange; 
    // Start is called before the first frame update
    void Start()
    {
        barrier.SetActive(true);
        swirl.SetActive(true);
        magicRock.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown("e"))
        {
            barrier.SetActive(false);
            // swirl.SetActive(false);
            Debug.Log("barrier is gone!");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("ladder in range");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("ladder not in range");
        }
    }
}
