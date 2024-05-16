using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMove : MonoBehaviour
{
    public float Speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = transform.localPosition;
        p.x += Speed * Time.smoothDeltaTime;
        if (p.x > 15)
            p.x = -15;
        transform.localPosition = p;
    
    }
}
