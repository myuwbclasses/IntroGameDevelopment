using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenArrowBehavior : MonoBehaviour
{
    private const float kDelta = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = transform.localPosition;

        if (Input.GetKey(KeyCode.W))
            p.y += kDelta;
        if (Input.GetKey(KeyCode.S))
            p.y -= kDelta;
        if (Input.GetKey(KeyCode.A))
            p.x -= kDelta;
        if (Input.GetKey(KeyCode.D))
            p.x += kDelta;

        transform.localPosition = p;
    }
}
