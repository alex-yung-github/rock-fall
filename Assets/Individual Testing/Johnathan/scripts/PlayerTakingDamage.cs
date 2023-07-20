using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakingDamage : MonoBehaviour
{
    public AttributesManager playerAtm;
    public AttributesManager enemyAtm;
    [SerializeField] private Rigidbody2D rb;
    public int knockback;
    public int maxVelocity;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.collider.name != "fireShield")
                enemyAtm.DealDamage(playerAtm.gameObject);
            else
            {
                Debug.Log("knockback");
                if (rb.velocity.x == 0 && rb.velocity.y == 0)
                {
                    rb.velocity = new Vector3(0.2f, 0.2f).normalized * knockback;
                }
                else if(rb.velocity.x < maxVelocity && rb.velocity.y < maxVelocity)
                {
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y).normalized * knockback;
                }
            }
        }
    }
  
}


