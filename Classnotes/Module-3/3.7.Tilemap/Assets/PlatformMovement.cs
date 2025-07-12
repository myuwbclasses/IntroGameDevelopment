using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Vector2 mDelta = new Vector2(2f, 2f);
    
    public Vector3 mSpeed = new Vector3(0.1f, 0.1f, 0f);
    
    private Vector2 mMovement = Vector3.zero;
    private Vector2 mDirection = Vector2.one;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 speed = mSpeed * mDirection * Time.smoothDeltaTime;
        mMovement.x += speed.x;
        mMovement.y += speed.y;
        transform.localPosition += speed;
        if (Mathf.Abs(mMovement.x) > Mathf.Abs(mDelta.x)) {
            mDirection.x *= -1f;
            mMovement.x = 0f;
        }
        if (Mathf.Abs(mMovement.y) > Mathf.Abs(mDelta.y)) {
            mDirection.y *= -1f;
            mMovement.y = 0f;
        }
    }
}
