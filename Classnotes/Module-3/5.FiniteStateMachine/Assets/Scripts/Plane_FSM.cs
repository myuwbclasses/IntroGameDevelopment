using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Plane : MonoBehaviour
{
    private enum EnemyState
    {
        eRestState,
        eEnlargeState,
        eCWRotateState,
        eCCWRotateState,
        eShrinkState
    };
    private const float kSizeChangeFrames = 120f;
    private const float kRotateFrames = 80f;
    private const float kScaleRate = 0.5f / 60f;// around per second rate
    private const float kRotateRate = 45f/60f;  // in degrees, around per second rate

    private int mStateFrameTick = 0;
    private EnemyState mState = EnemyState.eRestState;


    private void UpdateFSM()
    {
        switch (mState)
        {
            case EnemyState.eEnlargeState:
                ServiceEnlargeState();
                break;
            case EnemyState.eCWRotateState:
                ServiceCWState();
                break;
            case EnemyState.eCCWRotateState:
                ServiceCCWState();
                break;
            case EnemyState.eShrinkState:
                ServiceShrinkState();
                break;
            case EnemyState.eRestState:
                break;
        }
    }

    private void ServiceEnlargeState()
    {
        if (mStateFrameTick > kSizeChangeFrames)
        {
            // Transite to next state
            mState = EnemyState.eCWRotateState;
            mStateFrameTick = 0;
        }
        else
        {
            mStateFrameTick++;

            // assume scale in X/Y are the same
            float s = transform.localScale.x;
            s += kScaleRate;
            transform.localScale = new Vector3(s, s, 1);
        }
    }

    private void ServiceShrinkState()
    {
        if (mStateFrameTick > kSizeChangeFrames)
        {
            // Transite to next state
            mState = EnemyState.eRestState;
            mStateFrameTick = 0;
        }
        else
        {
            mStateFrameTick++;

            // assume scale in X/Y are the same
            float s = transform.localScale.x;
            s -= kScaleRate;
            transform.localScale = new Vector3(s, s, 1);
        }
    }

    private void ServiceCWState()
    {
        if (mStateFrameTick > kRotateFrames)
        {
            // Transite to next state
            mState = EnemyState.eCCWRotateState;
            mStateFrameTick = 0;
        }
        else
        {
            mStateFrameTick++;

            Vector3 angles = transform.rotation.eulerAngles;
            angles.z += kRotateRate;
            transform.rotation = Quaternion.Euler(0, 0, angles.z);
        }
    }

    private void ServiceCCWState()
    {
        if (mStateFrameTick > kRotateFrames)
        {
            // Transite to next state
            mState = EnemyState.eShrinkState;
            mStateFrameTick = 0;
        }
        else
        {
            mStateFrameTick++;

            Vector3 angles = transform.rotation.eulerAngles;
            angles.z -= kRotateRate;
            transform.rotation = Quaternion.Euler(0, 0, angles.z);
        }
    }


}
