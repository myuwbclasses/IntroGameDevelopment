using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenArrowBehavior : MonoBehaviour
{
    private GameObject mTarget = null;
    private const float kTurnRate = 0.2f;
    private const float kMySpeed = 5f;
    private const float kVeryClose = 5f;

    // Start is called before the first frame update
    void Start()
    {
        mTarget = Instantiate(Resources.Load("Prefabs/Egg") as GameObject);
        ComputeNewTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        PointAtPosition(mTarget.transform.localPosition, kTurnRate * Time.smoothDeltaTime);
        transform.localPosition += kMySpeed * Time.smoothDeltaTime * transform.up;

        CheckTargetPosition();

        if (Input.GetKeyDown(KeyCode.H))
        {
            mTarget.SetActive(!mTarget.activeSelf);
        }
    }

    private void ComputeNewTargetPosition()
    {
        // Access the GameManager
        Bounds targetB = GameManager.TheGameManager().GetTargetBound();
        float x = targetB.min.x + Random.value * targetB.size.x;
        float y = targetB.min.y + Random.value * targetB.size.y;
        mTarget.transform.localPosition = new Vector3(x, y, mTarget.transform.localPosition.z);
                        // ** IMPORTANT: to NOT change the z of mTarget
                        //    TRY: changing the Z to e.g., 2.0f, and watch 
                        //         Arrow sometimes "flips"
    }

    private void CheckTargetPosition()
    {
        // Access the GameManager
        float dist = Vector3.Distance(mTarget.transform.localPosition, transform.localPosition);
        if (dist < kVeryClose)
            ComputeNewTargetPosition();
    }

    private void PointAtPosition(Vector3 p, float r)
    {
        Vector3 v = p - transform.localPosition;
        transform.up = Vector3.LerpUnclamped(transform.up, v, r);
    }

}
