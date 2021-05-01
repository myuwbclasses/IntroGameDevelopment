using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Required to work with UI, e.g., Text

public class GameManager : MonoBehaviour
{
    public static GameManager sTheGlobalBehavior = null; // Single pattern


    public GreenArrowBehavior mHero = null;  // must set in the editor

    // for display egg count
    public Text mEggCountEcho = null;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.sTheGlobalBehavior = this;  // Singleton pattern
        Debug.Assert(mEggCountEcho != null);    // Assume setting in the editor!
        Debug.Assert(mHero != null);

        // Connect up everyone who needs to know about each other
        EggBehavior.SetGreenArrow(mHero);
        // Notice the symantics: this is a call to class method (NOT instance method)
    }

    // Update is called once per frame
    void Update()
    {
        mEggCountEcho.text = mHero.EggStatus();
    }

}
