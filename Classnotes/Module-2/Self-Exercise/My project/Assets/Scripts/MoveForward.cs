using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float Speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        float r = Random.Range(-180f, 180f);
        transform.localRotation = Quaternion.AngleAxis(r, Vector3.forward);

        Speed = Random.Range(0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Speed * Time.smoothDeltaTime * transform.up;
            // transform.up is changed by the rotation 
        
        Camera c = Camera.main;  // this is the main camera component
        if (c != null) {
            // Camera's bounds
            float cameraHalfHeight = c.orthographicSize;
            float cameraHalfWidth = cameraHalfHeight * c.aspect; // W/H is aspect ratio
            Vector3 cameraAt = c.gameObject.transform.localPosition;
            float maxY = cameraAt.y + cameraHalfHeight;
            float minY = cameraAt.y - cameraHalfHeight;
            float maxX = cameraAt.x + cameraHalfWidth;
            float minX = cameraAt.x - cameraHalfWidth;

            // my position
            Vector3 myP = transform.localPosition;

            if ((myP.y < minY) || (myP.y > maxY) ||
                (myP.x < minX) || (myP.x > maxX)) {  // outside!
                Debug.Log(gameObject.name + ": Outside!");
                Destroy(gameObject);
            }
        }
        
    }
}
