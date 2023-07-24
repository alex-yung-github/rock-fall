using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxSpeed;
    private int defaultMaxSpeed;
    [HideInInspector] public bool speedAltered;

    public int recoilForce;
    private int defaultRecoilForce;
    [HideInInspector] public bool recoilAltered;

    public int rockCooldown;
    private int defaultRockCooldown;
    [HideInInspector] public bool rockCooldownAltered;

    public float jumpingPower;
    private float defaultJumpingPower;
    [HideInInspector] public bool jumpingPowerAltered;

    public int health;
    private int defaultHealth;
    [HideInInspector] public bool healthAltered;

    public int attack;
    private int defaultAttack;
    [HideInInspector] public bool attackAltered;

    void Start()
    {
        defaultMaxSpeed = maxSpeed;
        speedAltered = false;

        defaultRecoilForce = recoilForce;
        recoilAltered = false;

        defaultRockCooldown = rockCooldown;
        rockCooldownAltered = false;

        defaultJumpingPower = jumpingPower;
        jumpingPowerAltered = false;

        defaultHealth = health;
        healthAltered = false;

        defaultAttack = attack;
        attackAltered = false;
    }

    void Update()
    {
        if(!speedAltered)
        {
            maxSpeed = defaultMaxSpeed;
        }
        if(!recoilAltered)
        {
            recoilForce = defaultRecoilForce;
        }
        if(!rockCooldownAltered)
        {
            rockCooldown = defaultRockCooldown;
        }
        if(!jumpingPowerAltered)
        {
            jumpingPower = defaultJumpingPower;
        }
        if(!healthAltered)
        {
            health = defaultHealth;
        }
        if(!attackAltered)
        {
            attack = defaultAttack;
        }
    }
    
}
