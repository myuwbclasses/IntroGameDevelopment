using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // I-key toggles idle
        if (Input.GetKeyDown(KeyCode.I)) {
            Animator a = GetComponent<Animator>();
            bool idle = a.GetBool("Idle");
            if (idle) // currently in idle?
                a.CrossFade("Her_Entire_Sheet", 10f); 
                    // go there after 10x Idle cycle time
                    // NOTE: there is an attempted blending by default
                    //       Her_Entire_Sheet will begin, while Idle is still running
                    //       Run the editor with Animator window open and HerPlayer selected
            else
                a.CrossFade("Her_Idle", 0.1f); // go there FAST!
            a.SetBool("Idle", !idle);
            
        }
            
    }
}
