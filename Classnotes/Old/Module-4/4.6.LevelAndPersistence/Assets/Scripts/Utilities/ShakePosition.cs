using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakePosition 
{
    private Vector2 mShakeDelta;
    private float mDuration;
    private float mOmega;

    // runtime
    private float mSecLeft = 0;
    private Vector3 mOrgPos;

    public ShakePosition(float frequency, float durationInSec)
    {
        SetShakeParameters(frequency, durationInSec);
    }

    public void SetShakeParameters(float frequency, float durationInSections)
    {
        mDuration = durationInSections;
        mOmega = frequency * 2 * Mathf.PI;
    }
    public void SetShakeMagnitude(Vector2 magnitude, Vector3 OrgPos) {
        mOrgPos = OrgPos;
        mShakeDelta = magnitude;
        mSecLeft = mDuration;
    }

    public Vector3 UpdateShake()
    {
        mSecLeft -= Time.smoothDeltaTime;
        Vector3 c = mOrgPos;
        if (!ShakeDone())
        {
            float v = NextDampedHarmonic();
            float fx = Random.Range(0f, 1f) > 0.5f ? -v : v;
            float fy = Random.Range(0f, 1f) > 0.5f ? -v : v;
            c.x += mShakeDelta.x * fx;
            c.y += mShakeDelta.y * fy;
        }
        return c;
    }

    public bool ShakeDone() { return mSecLeft <= 0f; }

    private float NextDampedHarmonic()
    {
        // computes (Cycles) * cos(  Omega * t )
        var frac = mSecLeft / mDuration;
        return frac * frac * Mathf.Cos((1 - frac) * this.mOmega);
    }
    
}
