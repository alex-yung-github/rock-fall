using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoulderScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boulder;
    void Start()
    {
        boulder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        boulder.SetActive(true);
    }
}
