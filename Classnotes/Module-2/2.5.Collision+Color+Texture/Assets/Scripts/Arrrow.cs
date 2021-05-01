using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Arrow: Started");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Arrow: OnTriggerEnter2D");
        collision.gameObject.transform.position = Vector3.zero;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Arrow: OnTriggerStay2D");
        collision.gameObject.transform.position = Vector3.zero;
    }
}
