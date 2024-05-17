using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControlLogic : MonoBehaviour
{
    public GameObject mRefPoint = null;

    public CameraSupport mTheCamera = null;
    public SliderWithEcho mZoomFactor = null;

    public SliderWithEcho mDX = null;
    public SliderWithEcho mDY = null;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(mTheCamera != null);
        Debug.Assert(mZoomFactor != null);
        Debug.Assert(mDX != null);
        Debug.Assert(mDY != null);
    }

    // Update is called once per frame
    void Update()
    {
        CheckZoom();
        CheckPan();
    }

    private void CheckZoom()
    {
        if (Input.GetKeyDown(KeyCode.H))
            mTheCamera.Zoom(mZoomFactor.value());

        if (Input.GetKeyDown(KeyCode.J))
            mTheCamera.ZoomTowards(mRefPoint.transform.position, mZoomFactor.value());
    }

    private void CheckPan()
    {
        if (Input.GetKeyDown(KeyCode.N))
            mTheCamera.MoveBy(mDX.value(), mDY.value());
        if (Input.GetKeyDown(KeyCode.M))
            mTheCamera.MoveTo(mRefPoint.transform.position.x, mRefPoint.transform.position.y);
    }
}
