using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{
    public CameraSupport mTheCamera = null;
    public float WorldRegion = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(mTheCamera != null);
    }

    // Update is called once per frame
    void Update()
    {
        CameraSupport.WorldBoundStatus status = 
                mTheCamera.CollideWorldBound(GetComponent<Renderer>().bounds, WorldRegion);
        // Debug.Log("BoundCollisionStatus = " + status);

        if (status != CameraSupport.WorldBoundStatus.Inside)
            mTheCamera.ClampToWorldBound(transform, WorldRegion);
    }
}
