using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Static one instance in the world
    private static GameManager sGameManager = null;
    public static GameManager TheGameManager() { return sGameManager; }

    // Show the bonuds of the camera
    public CameraSupport mCameraSupport = null;  // Reference to the main camera
    public Transform mTargetBox = null;

    // Adjust the outer and inner bound
    public SliderWithEcho mTargetSize = null;

    // Must be called before Start (GreenArrow Start depends on sGameManager being defined!)
    void Awake()
    {
        sGameManager = this;

        Debug.Assert(mCameraSupport != null);
        Debug.Assert(mTargetBox != null);
        Debug.Assert(mTargetSize != null);

        ComputeTargetBound();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            // spawn a new gree arrow
            Instantiate(Resources.Load("Prefabs/GreenArrow"));
        }

        // ComputeTargetBound();
        //    This function only needs to be invoked when the TargetBoundSlider value is changed
        //    So, instead of calling this function at each update, 
        //    TargetBoundSlider calls NewTaretSize() when its value changes
        //
    }

    public Bounds GetTargetBound()
    {
        Bounds targetB = mCameraSupport.GetWorldBound();
        targetB.size = targetB.size * mTargetSize.value();
        return targetB;
    }

    public void NewTargetSize()
    {
        ComputeTargetBound();
        // Configured in the UI to call this function when slider bar changes
    }

    private void ComputeTargetBound()
    {
        Bounds targetB = GetTargetBound();

        Vector3 p = targetB.center;
        p.z = mTargetBox.localPosition.z;
        mTargetBox.localPosition = p;
        mTargetBox.localScale = targetB.size;
    }
}

