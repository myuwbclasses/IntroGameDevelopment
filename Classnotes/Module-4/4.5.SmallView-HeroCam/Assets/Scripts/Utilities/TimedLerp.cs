using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedLerp
{
    private float mLerpTime;
    private float mRate;
    private Vector2 mEnd;
    private Vector2 mCurrent;

    // the timed parameters
    private float mStartTime; //
    private bool mLerpEnded;

    public TimedLerp(float timeInSeconds, float rate)
    {
        SetLerpParms(timeInSeconds, rate);
        mLerpEnded = true;
    }
    public void SetLerpParms(float timeInSeconds, float rate)
    {
        mLerpTime = timeInSeconds;
        mRate = rate;
    }
    public void BeginLerp(Vector2 start, Vector2 end)
    {
        mCurrent = start;
        mEnd = end;
        mStartTime = Time.realtimeSinceStartup;
        mLerpEnded = false;
    }
    public Vector2 UpdateLerp()
    {
        mLerpEnded = ((Time.realtimeSinceStartup - mStartTime) > mLerpTime);
        if (mLerpEnded)
            mCurrent = mEnd;
        else 
            mCurrent += (mEnd - mCurrent) * (mRate * Time.smoothDeltaTime);
        return mCurrent;
    }
    public bool LerpIsActive() { return !mLerpEnded; }
}