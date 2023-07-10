using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemygettinghitbyrock : MonoBehaviour
{
    public AttributesManager playerAtm;
    public AttributesManager enemyAtm;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter");
        if (collision.gameObject.CompareTag("arm"))
        {
            Debug.Log("enter");
            playerAtm.DealDamage(enemyAtm.gameObject);
        }
      
    }
 
   
}
