using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    [SerializeField] private float yOffset;
    [SerializeField] private float yOffsetOriginal;
    public float cameraZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey("s"))
        {
            Vector3 tempPos = new Vector3(target.position.x, target.position.y - 4f, cameraZ);
            //Slerp is a function that interpolates between two vectors
            transform.position = Vector3.Slerp(transform.position, tempPos, .5f);
        }
        else
        {
            Vector3 newpos = new Vector3(target.position.x, target.position.y + yOffset, cameraZ);
            //Slerp is a function that interpolates between two vectors
            transform.position = Vector3.Slerp(transform.position, newpos, FollowSpeed);
        }
    }

}
