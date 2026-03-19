using UnityEngine;
using UnityEngine.InputSystem;

public class GreenArrowBehavior : MonoBehaviour
{
    private const float kDelta = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = transform.localPosition;

        if (Keyboard.current.wKey.isPressed)
            p.y += kDelta;
        if (Keyboard.current.sKey.isPressed)
            p.y -= kDelta;
        if (Keyboard.current.aKey.isPressed)
            p.x -= kDelta;
        if (Keyboard.current.dKey.isPressed)
            p.x += kDelta;

        transform.localPosition = p;
    }
}
