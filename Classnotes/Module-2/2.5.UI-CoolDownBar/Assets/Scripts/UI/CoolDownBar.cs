using UnityEngine;

public class CoolDownBar : MonoBehaviour
{
    // Duration, in seconds, before the bar is ready again.
    public float mSecToCoolDown = 1f;
    private float mLastTriggered = 0f;
    private bool mActive = false;
    private float mInitBarWidth = 0f;

    void Start()
    {
        RectTransform r = GetComponent<RectTransform>();
        mInitBarWidth = r.sizeDelta.x;

        // Start the timer from the scene's initial time.
        mLastTriggered = Time.time;
    }

    // Lets another component choose how long the next cooldown lasts.
    public void SetCoolDownLength(float s)
    {
        mSecToCoolDown = s;
    }

    // Starts the timer only when no cooldown is already running.
    // Returns false when a trigger is attempted during a cooldown.
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

    // Other components use this to decide whether an action can happen.
    public bool ReadyForNext()
    {
        return (!mActive);
    }

    void Update()
    {
        if (mActive)
            UpdateCoolDownBar();
    }

    // Calculates the remaining time and scales the bar to match it.
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

    // Returns a negative value when the cooldown has finished.
    private float SecondsTillNext()
    {
        float secLeft = -1; // Use a negative value when no cooldown is active.
        if (mActive)
        {
            float sinceLast = Time.time - mLastTriggered; 
                // elapsed time since the cooldown began.
            secLeft = mSecToCoolDown - sinceLast; 
                // Subtract elapsed time to get the remaining cooldown.
        }
        return secLeft; // the remaining time, or the negative finished signal.
    }
}
