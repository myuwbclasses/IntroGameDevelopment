using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitControl : MonoBehaviour
{
    public float OrbitRadius = 2.0f;
    public float OrbitSpeed = 360.0f / 10f; // 10 seconds per cycle
    public Transform HostXform = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(HostXform != null);
                
        // we follow the host object)
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        // we follow the host
        transform.position = HostXform.position + OrbitRadius * transform.right; ;

        // update our rotation (sattlite will rotate)
        Quaternion r = Quaternion.AngleAxis((OrbitSpeed*Time.smoothDeltaTime), Vector3.forward);
        transform.rotation = r * transform.rotation;
    }

}
