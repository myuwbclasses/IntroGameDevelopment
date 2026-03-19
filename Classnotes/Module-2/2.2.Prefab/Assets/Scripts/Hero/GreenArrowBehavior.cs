using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GreenArrowBehavior : MonoBehaviour
{
    public float mHeroSpeed = 20f;
    public float mHeroRotateSpeed = 90f / 2f; // 90-degrees in 2 seconds

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move this object to mouse position
        Vector3 p = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        p.z = 0f;
        transform.localPosition = p;

        // Now spawn an egg when space bar is hit
        // wasPressedThisFrame: event, only once per frame
        // isPressed: state, true as long as the key is held down
        // if (Keyboard.current.spaceKey.wasPressedThisFrame)
        if (Keyboard.current.spaceKey.isPressed)
        {
            GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject); // Prefab MUST BE locaed in Resources/Prefab folder!
            e.transform.localPosition = transform.localPosition;
            Debug.Log("Spawn Eggs:" + e.transform.localPosition);
        }
    }

}
