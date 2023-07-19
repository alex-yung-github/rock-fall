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

    void Start()
    {
        defaultMaxSpeed = maxSpeed;
        speedAltered = false;

        defaultRecoilForce = recoilForce;
        recoilAltered = false;
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
    }
    
}
