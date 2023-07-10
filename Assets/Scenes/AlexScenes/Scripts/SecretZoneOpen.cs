using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretZoneOpen : MonoBehaviour
{

    [SerializeField] private GameObject ShopKeeper;
    // Start is called before the first frame update
    void Start()
    {
        ShopKeeper.SetActive(false);
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            ShopKeeper.SetActive(true);
            gameObject.SetActive(false);

        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            ShopKeeper.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}
