using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenArrowBehavior : MonoBehaviour
{
    private int mTotalEggCount = 0;

    public SliderWithEcho mSpawnRate;
    private float mEggSpawnAt = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(mSpawnRate != null);   // Must be set in the editor
        mEggSpawnAt = Time.time;  // time since the beginning of frame
    }

    // Update is called once per frame
    void Update()
    {
        // Vertical: Up/Down-Arrow, or WS-keys
        transform.position += Input.GetAxis("Vertical") * transform.up; // Move arrow up/down

        // Horizontal: Left/Right-Arrow, or AD-Keys
        transform.position += Input.GetAxis("Horizontal") * transform.right; //Move arrow left/right

        // Now spawn an egg when space bar is hit
        if (Input.GetKey(KeyCode.Space))
        {
            if ((Time.time - mEggSpawnAt) > mSpawnRate.value())
            {
                GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject); // Prefab MUST BE locaed in Resources/Prefab folder!
                e.transform.localPosition = transform.localPosition;
                // Debug.Log("Spawn Eggs:" + e.transform.localPosition);
                mTotalEggCount++;

                mEggSpawnAt = Time.time;
            }
        }
    }
    
    public void OneLessEgg() { mTotalEggCount--;  }

    public string EggStatus() { return "Eggs on screen: " + mTotalEggCount; }

}
