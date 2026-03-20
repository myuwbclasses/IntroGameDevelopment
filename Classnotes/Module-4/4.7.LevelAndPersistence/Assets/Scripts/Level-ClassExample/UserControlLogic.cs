using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; // Required for scene management


public class UserControlLogic : MonoBehaviour
{
    public GameObject mRefPoint = null;

    public CameraSupport mTheCamera = null;

    public CameraSupport mSmallView = null;
    public SliderWithEcho mVX = null;
    public SliderWithEcho mVY = null;
    public SliderWithEcho mVW = null;
    public SliderWithEcho mVH = null;

    public TMP_Text GameStateEcho = null;

    public 
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(mTheCamera != null);
        Debug.Assert(mSmallView != null);
        Debug.Assert(mVX != null);
        Debug.Assert(mVW != null);
        Debug.Assert(mVH != null);
    }

    // Update is called once per frame
    void Update()
    {
        CheckZoom();
        CheckPan();

        #region  Perform Shake
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            mTheCamera.ShakeCamera(new Vector2(3f, 3f));
            GameState.sGameState.IncShakeCount();
        }
        #endregion

        #region SetViewport
        mSmallView.SetViewportMinPos(mVX.value(), mVY.value());
        mSmallView.SetViewprotSize(mVW.value(), mVH.value());
        #endregion

        // Loading new Level
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("NewLevel");
        }
        GameStateEcho.text = GameState.sGameState.EchoGameState();
    }

    private void CheckZoom()
    {
        if (Keyboard.current.hKey.wasPressedThisFrame)
            mTheCamera.Zoom(mVX.value());

        if (Keyboard.current.jKey.wasPressedThisFrame)
            mTheCamera.ZoomTowards(mRefPoint.transform.position, mVX.value());
    }

    private void CheckPan()
    {
        if (Keyboard.current.nKey.wasPressedThisFrame)
            mTheCamera.MoveBy(5f, 5f);
        if (Keyboard.current.mKey.wasPressedThisFrame)
            mTheCamera.MoveTo(mRefPoint.transform.position.x, mRefPoint.transform.position.y);
    }
}
