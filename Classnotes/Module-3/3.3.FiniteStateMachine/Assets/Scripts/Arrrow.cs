using UnityEngine;
using UnityEngine.InputSystem;

public class Arrrow : MonoBehaviour
{
    const float kSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Arrow: Started");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;
        if (Keyboard.current.wKey.isPressed)
            movement.y += 1;
        if (Keyboard.current.sKey.isPressed)
            movement.y -= 1;
        if (Keyboard.current.aKey.isPressed)
            movement.x -= 1;
        if (Keyboard.current.dKey.isPressed)
            movement.x += 1;

        // Vertical: Up/Down-Arrow, or WS-keys
        transform.localPosition += movement.y * transform.up *
                                    (kSpeed * Time.smoothDeltaTime);
        // Horizontal: Left/Right-Arrow, or AD-Keys
        transform.localPosition += movement.x * transform.right *
                                    (kSpeed * Time.smoothDeltaTime);
    }
}
