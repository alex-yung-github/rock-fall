using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesManager : MonoBehaviour
{
    public int health;
    public int attack;

    public void takeDamage(int amount)
    {
        health -= amount;
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

