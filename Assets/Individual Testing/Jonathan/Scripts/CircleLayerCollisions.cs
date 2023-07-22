using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleLayerCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    public int shieldLayer;
    public int enemyLayer;
    void Start()
    {
        for(int i = 3; i < 20; i++)
        {
            if(i != enemyLayer)
            {
                Physics2D.IgnoreLayerCollision(shieldLayer, i, true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
