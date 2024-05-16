using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float Speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        float r = Random.Range(-45f, 45f);
        transform.localRotation = Quaternion.AngleAxis(r, Vector3.forward);

        Speed = Random.Range(5f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Speed * Time.smoothDeltaTime * transform.up;
            // transform.up is changed by the rotation 
        
        CameraSupport s = Camera.main.gameObject.GetComponent<CameraSupport>();
        if (s != null) {
            if (s.CollideWorldBound(gameObject.GetComponent<Renderer>().bounds) 
                    == CameraSupport.WorldBoundStatus.Outside) {
                Destroy(gameObject);
            }
        }
        
    }
}
