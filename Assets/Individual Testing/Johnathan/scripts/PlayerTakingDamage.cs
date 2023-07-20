using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakingDamage : MonoBehaviour
{
    public AttributesManager playerAtm;
    public AttributesManager enemyAtm;
    [SerializeField] private Rigidbody2D rb;
    // public int knockback;
    // public int maxVelocity;
    public float knockbackForce;
    public float knockbackC;
    public float knockbackTime;
    public bool knockFromRight;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.collider.name != "fireShield")
                enemyAtm.DealDamage(playerAtm.gameObject);
            else
            {
                Debug.Log("knockback");
                if (collision.transform.position.x > transform.position.x)
                {
                    rb.velocity = new Vector2(-knockbackForce, knockbackForce);
                }
                else
                {
                    rb.velocity = new Vector2(knockbackForce, knockbackForce);
                }
            }
        }
    }
  
}


