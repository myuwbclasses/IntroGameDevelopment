using UnityEngine;	
using System.Collections;

public class HeroControl : MonoBehaviour {

    public CameraSupport mTheCamera;
    public CameraSupport mHeroCam;
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
        transform.position += Input.GetAxis ("Vertical")  * transform.up * 
									(kHeroSpeed * Time.smoothDeltaTime);
        transform.position += Input.GetAxis("Horizontal") * transform.right *
                                    (kHeroSpeed * Time.smoothDeltaTime);
        #endregion

        mHeroCam.MoveTo(transform.position.x, transform.position.y);

        #region Testing the Camera Support: Push and Collision Bound
        mTheCamera.PushCameraByPos(transform.position, WorldBoundRegion);

        // testing the intersection
        CameraSupport.WorldBoundStatus status = mTheCamera.CollideWorldBound(GetComponent<Renderer>().bounds, WorldBoundRegion);
        // Debug.Log("Hero Collision=" + status);
        #endregion

        #region Testing TimedLerp: using size

        if (Input.GetKeyDown(KeyCode.Z))
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
