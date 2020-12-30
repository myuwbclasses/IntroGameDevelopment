using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Plane : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Plane: Started");

        // randomize state length
        mSizeChangeFrames += Random.Range(-30, 30);  // 
        mRotateFrames += Random.Range(-20, 20);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFSM();
    }
}
