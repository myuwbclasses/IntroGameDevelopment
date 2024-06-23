using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (Input.GetKeyDown(KeyCode.Space)) {
            mFollowMousePosition = !mFollowMousePosition;
            Debug.Log("Current control mode Mouse=" + mFollowMousePosition);
            if (mFollowMousePosition)
                GetComponent<SpriteRenderer>().color = mMouseColor;
            else
                GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (mFollowMousePosition)
        {
            p = mTheCamera.ScreenToWorldPoint(Input.mousePosition);
            // Alternates:
            //     p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //     p = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            p.z = 0f;  // <-- this is VERY IMPORTANT!
            // Debug.Log("Screen Point:" + Input.mousePosition + "  World Point:" + p);
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
                p += ((mHeroSpeed* Time.smoothDeltaTime) * transform.up);

             if (Input.GetKey(KeyCode.S))
                p -= ((mHeroSpeed * Time.smoothDeltaTime) * transform.up);

            if (Input.GetKey(KeyCode.A))
                transform.Rotate(transform.forward,  mHeroRotateSpeed * Time.smoothDeltaTime);

            if (Input.GetKey(KeyCode.D))
                transform.Rotate(transform.forward, -mHeroRotateSpeed * Time.smoothDeltaTime);
        }

        transform.localPosition = p;
    }
}
