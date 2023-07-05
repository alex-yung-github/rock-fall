using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockShot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private int p_rock_bullets = 2;
    public bool canFire;

    public GameObject frontArm;
    public GameObject backArm;

    public Vector2 screenPosition;
    private int p_rock_recharge_count = 0;

    // Start is called before the first frame update
    void Start()
    {
        p_rock_bullets = 2;
    }


    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0) && p_rock_bullets > 0)
        {
            /*
            screenPosition = Input.mousePosition;
            GameObject obj = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            obj.GetComponent<Rigidbody2D>().velocity = transform.GetComponent<Rigidbody2D>().velocity * 3;
            */
            if(p_rock_bullets == 2)
            {
                frontArm.SetActive(false);
                p_rock_bullets -= 1;
            }
            else
            {
                backArm.SetActive(false);
                p_rock_bullets -= 1;
                canFire = false;
            }

            
        }
    }

    public void FixedUpdate()
    {
        if(p_rock_bullets == 0)
        {
            if(p_rock_recharge_count >= 300)
            {
                canFire = true;
                frontArm.SetActive(true);
                backArm.SetActive(true);
                p_rock_recharge_count = 0;
                p_rock_bullets += 2;
            }
            else
            {
                p_rock_recharge_count += 1;
            }
        }
    }
}
