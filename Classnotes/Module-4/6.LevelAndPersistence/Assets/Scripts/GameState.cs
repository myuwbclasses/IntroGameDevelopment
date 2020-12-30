using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState 
{
    // This is roughly how you will implement Game State!
    private int mCameraShakeCount = 0;
    private int mHeroSizeLerpCount = 0;

    static public GameState sGameState = new GameState();

    private GameState()  // Can only be constructed from within
    {}

    public void IncShakeCount() { mCameraShakeCount++; }
    public void IncLerpCount() { mHeroSizeLerpCount++; }
    public string EchoGameState() {
        return "CameraShake(" + mCameraShakeCount + ")   HeroLerp(" + mHeroSizeLerpCount + ")";
    }
}
