using UnityEngine;
using UnityEngine.InputSystem;

public class GreenArrowBehavior : MonoBehaviour
{
    public Camera mTheCamera = null;
    public bool mFollowMousePosition = true;
    public float mHeroSpeed = 20f;
    [SerializeField] 
    private float mHeroRotateSpeed = 90f / 2f; // 90-degrees in 2 seconds

    private Color mMouseColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(mTheCamera != null); // must be set in the editor before starting the game!
        GetComponent<SpriteRenderer>().color = mMouseColor;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = transform.localPosition;

        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            mFollowMousePosition = !mFollowMousePosition;
            Debug.Log("Current control mode Mouse=" + mFollowMousePosition);
            if (mFollowMousePosition)
                GetComponent<SpriteRenderer>().color = mMouseColor;
            else
                GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (mFollowMousePosition)
        {
            p = mTheCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            // Alternates:
            //     p = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            //     p = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(Mouse.current.position.ReadValue());
            p.z = 0f;  // <-- this is VERY IMPORTANT!
            // Debug.Log("Screen Point:" + Mouse.current.position.ReadValue() + "  World Point:" + p);
        }
        else
        {
            if (Keyboard.current.wKey.isPressed)
                p += ((mHeroSpeed* Time.smoothDeltaTime) * transform.up);

             if (Keyboard.current.sKey.isPressed)
                p -= ((mHeroSpeed * Time.smoothDeltaTime) * transform.up);

            if (Keyboard.current.aKey.isPressed)
                transform.Rotate(transform.forward,  mHeroRotateSpeed * Time.smoothDeltaTime);

            if (Keyboard.current.dKey.isPressed)
                transform.Rotate(transform.forward, -mHeroRotateSpeed * Time.smoothDeltaTime);
        }

        transform.localPosition = p;
    }
}
