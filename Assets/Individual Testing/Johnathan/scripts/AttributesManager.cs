using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesManager : MonoBehaviour
{
    private int maxHealth;
    public int health;
    public int attack;

    public HealthBar healthBar;
    public PlayerStats playerStats;

    public bool isPlayer;
    
    void Start()
    {
        if (isPlayer)
        {
            maxHealth = playerStats.health;
            health = maxHealth;
            healthBar.SetMaxHealth(maxHealth);

            attack = playerStats.attack;
        }
    }
    void Update()
    {
        if(isPlayer && playerStats.health != maxHealth)
        {
            maxHealth = playerStats.health;
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(health);
        }
    }
    public void takeDamage(int amount)
    {
        health -= amount;
        if(isPlayer)
        {
            healthBar.SetHealth(health);
        }
        
        if(health == 0)
        {
            perish();
        }
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<AttributesManager>();
        if (atm != null)
        {
            atm.takeDamage(attack);
        }
    }
    void perish()
    {
        if(!this.gameObject.CompareTag("Player"))
        {
            GetComponent<LootBag>().InstantiateLoot(transform.position);
        }
        Destroy(this.gameObject);
    

    }
}

