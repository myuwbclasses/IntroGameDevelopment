using UnityEngine;
using UnityEngine.InputSystem;

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
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            mTheCamera.SetShakeParameters(mFreg.value(), mDuration.value());
            mTheCamera.ShakeCamera(new Vector2(mDX.value(), mDY.value()));
        }
    }

    private void CheckZoom()
    {
        if (Keyboard.current.hKey.wasPressedThisFrame)
            mTheCamera.Zoom(mFreg.value());

        if (Keyboard.current.jKey.wasPressedThisFrame)
            mTheCamera.ZoomTowards(mRefPoint.transform.position, mFreg.value());
    }

    private void CheckPan()
    {
        if (Keyboard.current.nKey.wasPressedThisFrame)
            mTheCamera.MoveBy(5f, 5f);
        if (Keyboard.current.mKey.wasPressedThisFrame)
            mTheCamera.MoveTo(mRefPoint.transform.position.x, mRefPoint.transform.position.y);
    }
}
