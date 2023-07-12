using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakingDamage : MonoBehaviour
{
    public AttributesManager playerAtm;
    public AttributesManager enemyAtm;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("enter");
            enemyAtm.DealDamage(playerAtm.gameObject);
        }

    }
}


