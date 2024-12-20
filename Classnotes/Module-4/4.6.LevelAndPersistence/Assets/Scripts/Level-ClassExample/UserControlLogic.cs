﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // for Loading Scene!!

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
        if (Input.GetKeyDown(KeyCode.X))
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
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("NewLevel");
        }
        GameStateEcho.text = GameState.sGameState.EchoGameState();
    }

    private void CheckZoom()
    {
        if (Input.GetKeyDown(KeyCode.H))
            mTheCamera.Zoom(mVX.value());

        if (Input.GetKeyDown(KeyCode.J))
            mTheCamera.ZoomTowards(mRefPoint.transform.position, mVX.value());
    }

    private void CheckPan()
    {
        if (Input.GetKeyDown(KeyCode.N))
            mTheCamera.MoveBy(5f, 5f);
        if (Input.GetKeyDown(KeyCode.M))
            mTheCamera.MoveTo(mRefPoint.transform.position.x, mRefPoint.transform.position.y);
    }
}
