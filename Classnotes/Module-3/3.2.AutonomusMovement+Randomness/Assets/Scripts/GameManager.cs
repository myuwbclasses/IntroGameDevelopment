using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Static one instance in the world
    private static GameManager sGameManager = null;
    public static GameManager TheGameManager() { return sGameManager; }

    public Transform mTargetBox = null;

    // Adjust the outer and inner bound
    public SliderWithEcho mTargetSize = null;

    // Must be called before Start (GreenArrow Start depends on sGameManager being defined!)
    void Awake()
    {
        sGameManager = this;

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
        Camera c = Camera.main;
        float ySize = c.orthographicSize * 2f * mTargetSize.value();  // size is half of height
        float xSize = ySize * c.aspect;
        Vector3 p = c.gameObject.transform.localPosition; // Center of target is center of camera
        p.z = mTargetBox.localPosition.z;

        Bounds targetB = new Bounds();
        targetB.center = p;
        targetB.size = new Vector3(xSize, ySize, 1f);
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

