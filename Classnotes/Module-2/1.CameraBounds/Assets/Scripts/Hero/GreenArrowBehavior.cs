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

        // 1. Find the main camera and get the CameraSupport component
        CameraSupport s = Camera.main.GetComponent<CameraSupport>();  // Try to access the CameraSupport component on the MainCamera
        if (s != null)   // if main camera does not have the script, this will be null
        {
            // intersect my bond with the bounds of the world
            Bounds myBound = GetComponent<Renderer>().bounds;  // this is the bound on the SpriteRenderer
            CameraSupport.WorldBoundStatus status = s.CollideWorldBound(myBound);
            
            // If result is not "inside", then, move the hero to a random position
            if (status != CameraSupport.WorldBoundStatus.Inside)
            {
                Debug.Log("Touching the world edge: " + status);
                // now let's re-spawn ourself somewhere in the world
                p.x = s.GetWorldBound().min.x + Random.value * s.GetWorldBound().size.x;
                p.y = s.GetWorldBound().min.y + Random.value * s.GetWorldBound().size.y;
            }
        }

        transform.localPosition = p;
    }
}
