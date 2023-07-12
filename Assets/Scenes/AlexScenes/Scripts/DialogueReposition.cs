using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueReposition : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform rectTransform;
    public float m_XAxis, m_YAxis;
    public bool complete = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // if(rectTransform != null && complete == false){
        //     rectTransform.transform = new Vector2(m_XAxis, m_YAxis);
        //     complete = true;
        // }
    }
}
