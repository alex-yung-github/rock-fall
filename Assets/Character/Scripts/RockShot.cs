using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockShot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public Inventory inventory;
    private int p_rock_bullets = 2;
    public bool canFire;
    [HideInInspector] public bool inventoryOpen;

    public GameObject frontArm;
    public GameObject backArm;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public Vector2 screenPosition;
    public int p_rock_recharge_count = 50;
    public RockBar rockBar;

    // Start is called before the first frame update
    void Start()
    {
        p_rock_bullets = 2;
        rockBar.SetMaxCooldown(p_rock_recharge_count);
    }


    // Update is called once per frame
    void Update()
    { 
        if(inventory.inventoryEnabled)
        {
            inventoryOpen = true;
        }
        else
        {
            inventoryOpen = false;
        }
        if (Input.GetMouseButtonDown(0) && p_rock_bullets > 0 && !inventoryOpen)
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
            }
        }
    }

    public void FixedUpdate()
    {
        rockBar.SetCooldown(p_rock_recharge_count);
        if(p_rock_bullets == 0)
        {
            canFire = false;
            if(p_rock_recharge_count == 0 && Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer))
            {
                canFire = true; //this variable is sent to the Shooting.cs file to determine if bullet can be instantiated
                frontArm.SetActive(true);
                backArm.SetActive(true);
                p_rock_recharge_count = 50;
                p_rock_bullets += 2;
            }
            else if (p_rock_recharge_count > 0)
            {
                p_rock_recharge_count -= 1;
            }
        }
        if(p_rock_bullets == 1)
        {
            canFire = true;
            if(p_rock_recharge_count == 0 && Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer))
            {
                frontArm.SetActive(true);
                backArm.SetActive(true);
                p_rock_recharge_count = 50;
                p_rock_bullets += 1;
            }
            else if (p_rock_recharge_count > 0)
            {
                p_rock_recharge_count -= 1;
            }
        }
    }
}
