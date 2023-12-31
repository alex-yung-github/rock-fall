using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public RockShot rockShot;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if(Input.GetMouseButtonDown(0) && rockShot.inventoryOpen == false && playerMovement.shopOpen == false && rockShot.canFire)
        {
            var clone = Instantiate(bullet, bulletTransform.position, Quaternion.identity); //create bullet clone
            Destroy(clone, 5); //destroy it after 5 seconds
        }
    }
}
