using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenArrowBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Move this object to mouse position
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        transform.localPosition = p;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with" + collision.gameObject.name);
        Destroy(collision.gameObject);
    }

}
