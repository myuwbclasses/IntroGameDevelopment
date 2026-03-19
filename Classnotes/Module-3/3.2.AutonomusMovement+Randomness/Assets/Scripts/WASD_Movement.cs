using UnityEngine;
using UnityEngine.InputSystem;

public class WASD_Movement : MonoBehaviour
{
    private float kSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            movement.y += 1f;
        }
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            movement.y -= 1f;
        }
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            movement.x -= 1f;
        }
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            movement.x += 1f;
        }


        // Vertical: Up/Down-Arrow, or WS-keys
        transform.localPosition += movement.y * transform.up *
                                    (kSpeed * Time.smoothDeltaTime);
        // Horizontal: Left/Right-Arrow, or AD-Keys
        transform.localPosition += movement.x * transform.right *
                                    (kSpeed * Time.smoothDeltaTime);
    }
}
