using UnityEngine;
using UnityEngine.InputSystem;

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
        if (Keyboard.current.hKey.wasPressedThisFrame)
            mTheCamera.Zoom(mZoomFactor.value());

        if (Keyboard.current.jKey.wasPressedThisFrame)
            mTheCamera.ZoomTowards(mRefPoint.transform.position, mZoomFactor.value());
    }

    private void CheckPan()
    {
        if (Keyboard.current.nKey.wasPressedThisFrame)
            mTheCamera.MoveBy(mDX.value(), mDY.value());
        if (Keyboard.current.mKey.wasPressedThisFrame)
            mTheCamera.MoveTo(mRefPoint.transform.position.x, mRefPoint.transform.position.y);
    }
}
