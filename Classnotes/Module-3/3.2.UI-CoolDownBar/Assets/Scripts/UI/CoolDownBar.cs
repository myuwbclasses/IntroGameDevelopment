using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownBar : MonoBehaviour
{
    public float mSecToCoolDown = 1f;
    private float mLastTriggered = 0f;
    private bool mActive = false;
    private float mInitBarWidth = 0f;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform r = GetComponent<RectTransform>();
        mInitBarWidth = r.sizeDelta.x;  // This is the width of the Rect Transform

        mLastTriggered = Time.time; // time last triggered
    }

    // Update is called once per frame
    void Update()
    {
        if (mActive)
            UpdateCoolDownBar();
    }

    private void UpdateCoolDownBar()
    {
        float sec = SecondsTillNext();
        float percentage = sec / mSecToCoolDown;

        if (sec < 0)
        {
            mActive = false;
            percentage = 1.0f;
        }
            
        Vector2 s = GetComponent<RectTransform>().sizeDelta;
        s.x = percentage * mInitBarWidth;
        GetComponent<RectTransform>().sizeDelta = s;
    }

    public void SetCoolDownLength(float s)
    {
        mSecToCoolDown = s;
    }

    private float SecondsTillNext()
    {
        float secLeft = -1;
        if (mActive)
        {
            float sinceLast = Time.time - mLastTriggered;
            secLeft = mSecToCoolDown - sinceLast;
        }
        return secLeft;
    }

    // returns if trigger is successful
    public bool TriggerCoolDown()
    {
        bool canTrigger = !mActive;
        if (canTrigger)
        {
            mActive = true;
            mLastTriggered = Time.time;
            UpdateCoolDownBar();
        }
        return canTrigger;
    }

    public bool ReadyForNext()
    {
        return (!mActive);
    }
}
