using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Plane : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Plane: Started");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFSM();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Plane: OnTriggerEnter2D");
        mState = EnemyState.eEnlargeState;
        mStateFrameTick = 0;
    }

}
