using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    private Rigidbody2D mHeroPhysics;
    [SerializeField] private float mSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        mHeroPhysics = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        float d = mSpeed * Time.smoothDeltaTime;

        if (Input.GetKey(KeyCode.A)) {
            transform.localPosition += new Vector3(-d, 0, 0);
                // Note: this is updating the position (no physics)
        }

        if (Input.GetKey(KeyCode.D)) {
            Collider2D other = GameObject.Find("ThePlatform - Brown").GetComponent<Collider2D>();
            if (mHeroPhysics.IsTouching(other) ||  // right movement can only occur on platform
               (!mHeroPhysics.IsTouchingLayers(LayerMask.NameToLayer("Default")) ) // or not touching any objects in the Default layer 
            ) { 
                Debug.Log("Hero is touching: " + other.gameObject + " or nothing");
                mHeroPhysics.velocity = new Vector2(mSpeed, 0);
                // Note: this is changing velocity
            }
        }

        if (Input.GetKey(KeyCode.W)) {
            transform.localPosition += new Vector3(0, d, 0);
                // Note: this is updating the position (no physics)
        }

        if (Input.GetKey(KeyCode.Space)) {
            mHeroPhysics.velocity = new Vector2(0, mSpeed);
                // Note: this is changing velocity
        }

    }

    void OnCollisionEnter2D(Collision2D other) {
        // Note: the Hero's Collider.isTriggered is OFF
        //   When this is off, will collide with all Collider2D with isTriggered Off
        Debug.Log("Hero CollisionEnter:" + other.gameObject.name);
    }

    void OnCollisionStay2D(Collision2D other) {
        Debug.Log("Hero CollisionStay:" + other.gameObject.name);
    }

    void OnCollisionExit2D(Collision2D other) {
        Debug.Log("Hero CollisionExit:" + other.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Hero TriggerEnter:" + other.gameObject.name);
    }

    void OnTriggerStay2D(Collider2D other) {
        Debug.Log("Hero TriggerStay:" + other.gameObject.name);
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("Hero TriggerExit:" + other.gameObject.name);
    }
}
