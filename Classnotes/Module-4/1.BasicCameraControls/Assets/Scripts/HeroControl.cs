using UnityEngine;	
using System.Collections;

public class HeroControl : MonoBehaviour {

    public CameraSupport mTheCamera;
    public float WorldBoundRegion = 0.8f;
	public float kHeroSpeed = 40f;
	private float kHeroRotateSpeed = 90f/2f; // 90-degrees in 2 seconds

	// Use this for initialization
	void Start () {
        Debug.Assert(mTheCamera != null);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Input.GetAxis ("Vertical")  * transform.up * 
									(kHeroSpeed * Time.smoothDeltaTime);
        transform.position += Input.GetAxis("Horizontal") * transform.right *
                                    (kHeroSpeed * Time.smoothDeltaTime);

        mTheCamera.PushCameraByPos(transform.position, WorldBoundRegion);

        // testing the intersection
        CameraSupport.WorldBoundStatus status = mTheCamera.CollideWorldBound(GetComponent<Renderer>().bounds, WorldBoundRegion);
        Debug.Log("Hero Collision=" + status);
	}
}
