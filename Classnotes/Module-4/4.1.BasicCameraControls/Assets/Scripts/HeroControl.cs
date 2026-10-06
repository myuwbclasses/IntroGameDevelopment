using UnityEngine;	
using UnityEngine.InputSystem;

public class HeroControl : MonoBehaviour {

    public CameraSupport mTheCamera;
    public float WorldBoundRegion = 0.8f;
	public float mHeroSpeed = 40f;

	// Use this for initialization
	void Start () {
        Debug.Assert(mTheCamera != null);
	}
	
	// Update is called once per frame
	void Update () {
		#region User Position Control
		float movement = 0f;
		if ((Keyboard.current.wKey.isPressed) || Keyboard.current.upArrowKey.isPressed)
			movement += 1f;
		if ((Keyboard.current.sKey.isPressed) || Keyboard.current.downArrowKey.isPressed)
			movement -= 1f;
		transform.position += movement * transform.up * 
									(mHeroSpeed * Time.smoothDeltaTime);
		
		movement = 0f;
		if ((Keyboard.current.dKey.isPressed) || Keyboard.current.rightArrowKey.isPressed)
			movement += 1f;
		if ((Keyboard.current.aKey.isPressed) || Keyboard.current.leftArrowKey.isPressed)
			movement -= 1f;		
        transform.position += movement * transform.right *
                                    (mHeroSpeed * Time.smoothDeltaTime);
        #endregion

        #region Testing the Camera Support: Push and Collision Bound
        mTheCamera.PushCameraByPos(transform.position, WorldBoundRegion);

        // testing the intersection
        CameraSupport.WorldBoundStatus status = mTheCamera.CollideWorldBound(GetComponent<SpriteRenderer>().bounds, WorldBoundRegion);
        // Debug.Log("Hero Collision=" + status);
        #endregion
    }
}
