using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isInRange; // is player in range of door?
    [SerializeField] private Rigidbody2D rb;
    private float upSpeed = 4f;
    private float vertical;
    private bool isClimbing;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if(isInRange && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * upSpeed);
        }
        else
        {
            rb.gravityScale = 4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isInRange = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
      
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isInRange = false;
            isClimbing = false;
           
        }
    }
}
