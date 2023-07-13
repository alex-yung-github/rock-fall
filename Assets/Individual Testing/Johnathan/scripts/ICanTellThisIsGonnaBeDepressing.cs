using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ICanTellThisIsGonnaBeDepressing : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    public GameObject thePlayer;
    private Transform playerPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;

    }

    // Update is called once per frame
    void Update()
    { 
        playerPoint = thePlayer.GetComponent<Rigidbody2D>().transform;
        float distance = Vector3.Distance(rb.transform.position, playerPoint.position);
        Debug.Log(distance);
        if  (distance >=15.0)
        {
            Debug.Log("AAAH");
            patrolling();
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
       
    }
    public void patrolling() { 
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }
}