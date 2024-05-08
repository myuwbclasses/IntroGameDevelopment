using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenArrowBehavior : MonoBehaviour
{
    public bool mFollowMousePosition = true;
    public float mHeroSpeed = 20f;
    public float mHeroRotateSpeed = 90f / 2f; // 90-degrees in 2 seconds

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = transform.localPosition;

        if (Input.GetKeyDown(KeyCode.Space))
            mFollowMousePosition = !mFollowMousePosition;

        if (mFollowMousePosition)
        {
            p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            p.z = 0f;  // <-- this is VERY IMPORTANT!
            // Debug.Log("Screen Point:" + Input.mousePosition + "  World Point:" + p);
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
                p += ((mHeroSpeed* Time.smoothDeltaTime) * transform.up);

             if (Input.GetKey(KeyCode.S))
                p -= ((mHeroSpeed * Time.smoothDeltaTime) * transform.up);

            if (Input.GetKey(KeyCode.A))
                transform.Rotate(transform.forward,  mHeroRotateSpeed * Time.smoothDeltaTime);

            if (Input.GetKey(KeyCode.D))
                transform.Rotate(transform.forward, -mHeroRotateSpeed * Time.smoothDeltaTime);

            CameraSupport s = Camera.main.GetComponent<CameraSupport>();  // Try to access the CameraSupport component on the MainCamera
            if (s != null)   // if main camera does not have the script, this will be null
            {
                Bounds myBound = GetComponent<Renderer>().bounds;  // this is the bound of the collider defined on GreenUp
                CameraSupport.WorldBoundStatus status = s.CollideWorldBound(myBound);

                if (status != CameraSupport.WorldBoundStatus.Inside)
                {
                    Debug.Log("Touching the world edge: " + status);
                    // now let's re-spawn ourself somewhere in the world
                    p.x = s.GetWorldBound().min.x + Random.value * s.GetWorldBound().size.x;
                    p.y = s.GetWorldBound().min.y + Random.value * s.GetWorldBound().size.y;
                }
            }
        }

        transform.localPosition = p;
    }
}
