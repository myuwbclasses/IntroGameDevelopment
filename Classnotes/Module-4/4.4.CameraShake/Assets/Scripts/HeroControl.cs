using UnityEngine;	
using UnityEngine.InputSystem;

public class HeroControl : MonoBehaviour {

    public CameraSupport mTheCamera;
    public float WorldBoundRegion = 0.8f;
	public float kHeroSpeed = 40f;
	private float kHeroRotateSpeed = 90f/2f; // 90-degrees in 2 seconds
                                             // Use this for initialization

    private TimedLerp mSizeLerp = new TimedLerp(1f, 0.5f);  // controls size change
    private const float kDeltaSize = 8f;  // Twice my current size

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
									(kHeroSpeed * Time.smoothDeltaTime);
		
		movement = 0f;
		if ((Keyboard.current.dKey.isPressed) || Keyboard.current.rightArrowKey.isPressed)
			movement += 1f;
		if ((Keyboard.current.aKey.isPressed) || Keyboard.current.leftArrowKey.isPressed)
			movement -= 1f;		
        transform.position += movement * transform.right *
                                    (kHeroSpeed * Time.smoothDeltaTime);
        #endregion

        #region Testing the Camera Support: Push and Collision Bound
        mTheCamera.PushCameraByPos(transform.position, WorldBoundRegion);

        // testing the intersection
        CameraSupport.WorldBoundStatus status = mTheCamera.CollideWorldBound(GetComponent<SpriteRenderer>().bounds, WorldBoundRegion);
        // Debug.Log("Hero Collision=" + status);
        #endregion

        #region Testing TimedLerp: using size

        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            Vector3 finalScale = transform.localScale;
            transform.localScale += new Vector3(kDeltaSize, kDeltaSize, 0f);
            mSizeLerp.SetLerpParms(3f, 2f);
            mSizeLerp.BeginLerp(transform.localScale, finalScale);
        }

        if (mSizeLerp.LerpIsActive())
        {
            Vector3 s = mSizeLerp.UpdateLerp();
            transform.localScale = new Vector3(s.x, s.y, 0.0f);
        }

        #endregion
        }
    }
