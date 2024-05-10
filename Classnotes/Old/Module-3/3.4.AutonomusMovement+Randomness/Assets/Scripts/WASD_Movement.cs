using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_Movement : MonoBehaviour
{
    private float kSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Vertical: Up/Down-Arrow, or WS-keys
        transform.localPosition += Input.GetAxis("Vertical") * transform.up *
                                    (kSpeed * Time.smoothDeltaTime);
        // Horizontal: Left/Right-Arrow, or AD-Keys
        transform.localPosition += Input.GetAxis("Horizontal") * transform.right *
                                    (kSpeed * Time.smoothDeltaTime);
    }
}
