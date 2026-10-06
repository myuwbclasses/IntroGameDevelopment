using UnityEngine;
using UnityEngine.InputSystem;

public class UserControlLogic : MonoBehaviour
{
    public GameObject mRefPoint = null;

    public CameraSupport mTheCamera = null;
    public SliderWithEcho mFreq = null;
    public SliderWithEcho mDuration = null;

    public SliderWithEcho mDX = null;
    public SliderWithEcho mDY = null;

    private const float kZoomFactor = 1.1f;   // H/J: > 1 zooms out (see more of the world)

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(mTheCamera != null);
        Debug.Assert(mFreq != null);
        Debug.Assert(mDuration != null);
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
            mTheCamera.SetShakeParameters(mFreq.value(), mDuration.value());
            mTheCamera.ShakeCamera(new Vector2(mDX.value(), mDY.value()));
        }
    }

    private void CheckZoom()
    {
        if (Keyboard.current.hKey.wasPressedThisFrame)
            mTheCamera.Zoom(kZoomFactor);

        if (Keyboard.current.jKey.wasPressedThisFrame)
            mTheCamera.ZoomTowards(mRefPoint.transform.position, kZoomFactor);
    }

    private void CheckPan()
    {
        if (Keyboard.current.nKey.wasPressedThisFrame)
            mTheCamera.MoveBy(5f, 5f);
        if (Keyboard.current.mKey.wasPressedThisFrame)
            mTheCamera.MoveTo(mRefPoint.transform.position.x, mRefPoint.transform.position.y);
    }
}
