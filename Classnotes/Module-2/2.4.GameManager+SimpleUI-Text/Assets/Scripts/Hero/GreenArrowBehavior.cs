using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenArrowBehavior : MonoBehaviour
{
    public float mHeroSpeed = 20f;
    public float mHeroRotateSpeed = 90f / 2f; // 90-degrees in 2 seconds

    private int mTotalEggCount = 0;
    public SliderWithEcho my_size = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(my_size != null);
        my_size.mSlider.minValue = 5;
        my_size.mSlider.maxValue = 50;

    }

    // Update is called once per frame
    void Update()
    {
        // Move this object to mouse position
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        transform.localPosition = p;

        // Now spawn an egg when space bar is hit
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject); // Prefab MUST BE locaed in Resources/Prefab folder!
            e.transform.localPosition = transform.localPosition;
            // Debug.Log("Spawn Eggs:" + e.transform.localPosition);
            mTotalEggCount++;
        }

        float s = my_size.value();
        transform.localScale = new Vector3(s, s, 1);
    }
    
    public void OneLessEgg() { mTotalEggCount--;  }

    public string EggStatus() { return "Eggs on screen: " + mTotalEggCount; }

}
