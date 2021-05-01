using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenArrowBehavior : MonoBehaviour
{
    public GameObject mMyTarget = null;
    public SliderWithEcho mTurnRate = null;
    private const float kMySpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(mMyTarget != null);
        Debug.Assert(mTurnRate != null);
    }

    // Update is called once per frame
    void Update()
    {

        PointAtPosition(mMyTarget.transform.localPosition, mTurnRate.value() * Time.smoothDeltaTime);
        transform.localPosition += kMySpeed * Time.smoothDeltaTime * transform.up;
    }

    private void PointAtPosition(Vector3 p, float r)
    {
        Vector3 v = p - transform.localPosition;
        transform.up = Vector3.LerpUnclamped(transform.up, v, r);
    }

}
