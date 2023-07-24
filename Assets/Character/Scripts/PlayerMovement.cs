using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower;
    private Camera mainCam;
    private Vector3 mousePos;
    public RockShot rockShot;
    private int boostCounter;
    //private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private int recoilForce; //can be tuned in Unity to improve usability
    private int maxSpeed;

    public PlayerStats playerStats;
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        boostCounter = 0;
        maxSpeed = playerStats.maxSpeed;
        recoilForce = playerStats.recoilForce;
        jumpingPower = playerStats.jumpingPower;
    }

    void Update()
    {
        if(inventory.inventoryEnabled)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        maxSpeed = playerStats.maxSpeed;
        recoilForce = playerStats.recoilForce;
        jumpingPower = playerStats.jumpingPower;
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if(Input.GetMouseButtonDown(0) && rockShot.canFire)
        {
            boostCounter = 5;
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePos - transform.position;
            Vector3 rotation = transform.position - mousePos;
            rb.velocity = new Vector3(direction.x * -1, direction.y * - 1).normalized * recoilForce; // .normalized after parenthesis decides whether or not strength scales
        }
        //Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed + rb.velocity.x, rb.velocity.y);
        if(horizontal == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.7f, rb.velocity.y);
        }
        if(rb.velocity.x > maxSpeed && boostCounter == 0)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        if(rb.velocity.x < maxSpeed * -1 && boostCounter == 0)
        {
            rb.velocity = new Vector2(maxSpeed * -1, rb.velocity.y);
        }
        if(boostCounter > 0)
        {
            boostCounter -= 1;
        }
    }
    
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    /*
    private void Flip() //flip method is not necessary if rocks are tracked by mouse position
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    */
}
   
