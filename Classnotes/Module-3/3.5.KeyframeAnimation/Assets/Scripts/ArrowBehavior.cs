using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Arrow: Trigger Enter!");
        Animator a = GetComponent<Animator>(); 
        if (a != null) 
            a.SetBool("Begin", true);
        
        Animator p = collision.gameObject.GetComponent<Animator>();
        p.SetBool("Dec", true);  // sets Dec to true
        p.CrossFade("DecSize", 0.2f);  // second parameter says "how fast": 0.2, is 20% of the current state's time
    }

    public void FromAnimation(string msg) {
        Debug.Log("Arrow received animation event:" + msg);
    }
}
