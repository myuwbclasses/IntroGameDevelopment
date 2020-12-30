using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControlLogic : MonoBehaviour
{
    public GameObject mRefPoint = null;

    public CameraSupport mTheCamera = null;
    public SliderWithEcho mFreg = null;
    public SliderWithEcho mDuration = null;

    public SliderWithEcho mDX = null;
    public SliderWithEcho mDY = null;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(mTheCamera != null);
        Debug.Assert(mFreg != null);
        Debug.Assert(mDX != null);
        Debug.Assert(mDY != null);
    }

    // Update is called once per frame
    void Update()
    {
        CheckZoom();
        CheckPan();

        // Perform Shake
        if (Input.GetKeyDown(KeyCode.X))
        {
            mTheCamera.SetShakeParameters(mFreg.value(), mDuration.value());
            mTheCamera.ShakeCamera(new Vector2(mDX.value(), mDY.value()));
        }
    }

    private void CheckZoom()
    {
        if (Input.GetKeyDown(KeyCode.H))
            mTheCamera.Zoom(mFreg.value());

        if (Input.GetKeyDown(KeyCode.J))
            mTheCamera.ZoomTowards(mRefPoint.transform.position, mFreg.value());
    }

    private void CheckPan()
    {
        if (Input.GetKeyDown(KeyCode.N))
            mTheCamera.MoveBy(5f, 5f);
        if (Input.GetKeyDown(KeyCode.M))
            mTheCamera.MoveTo(mRefPoint.transform.position.x, mRefPoint.transform.position.y);
    }
}
