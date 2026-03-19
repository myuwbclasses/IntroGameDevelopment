using UnityEngine;
using UnityEngine.InputSystem;

public class GreenArrowBehavior : MonoBehaviour
{
    private int mTotalEggCount = 0;

    public CoolDownBar mCoolDown;
    public SliderWithEcho mSpawnRate;
    private float mEggSpawnAt = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(mCoolDown != null);    // Must be set in the editor
        Debug.Assert(mSpawnRate != null);   // Must be set in the editor
        mEggSpawnAt = Time.time;  // time since the beginning of frame
    }

    // Update is called once per frame
    void Update()
    {
        // Vertical: WS-keys
        if (Keyboard.current.wKey.isPressed)
        {
            transform.position += transform.up;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            transform.position -= transform.up;
        }

        // Horizontal: AD-Keys
        if (Keyboard.current.aKey.isPressed)
        {
            transform.position -= transform.right;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            transform.position += transform.right;
        }

        // Now spawn an egg when space bar is hit
        if (Keyboard.current.spaceKey.isPressed)
        {
            if (mCoolDown.ReadyForNext())
            {
                GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject); // Prefab MUST BE locaed in Resources/Prefab folder!
                e.transform.localPosition = transform.localPosition;
                // Debug.Log("Spawn Eggs:" + e.transform.localPosition);
                mTotalEggCount++;

                mCoolDown.TriggerCoolDown();
            }
        }

        // make sure cool down period is that of the slider bar
        mCoolDown.SetCoolDownLength(mSpawnRate.value());
    }
    
    public void OneLessEgg() { mTotalEggCount--;  }

    public string EggStatus() { return "Eggs on screen: " + mTotalEggCount; }

}