using UnityEngine;
using UnityEngine.UI;  // Required to work with UI
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager sTheGlobalBehavior = null; // Single pattern

    public GreenArrowBehavior mHero = null;  // must set in the editor

    // for display egg count
    public TMP_Text mEggCountEcho = null;

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

    // Determines if a point is within the main camera bounds
    public bool IsInCameraBound(Vector3 pt)
    {
        float h = Camera.main.orthographicSize * 2f;
        float w = h * Camera.main.aspect;
        Vector3 p = Camera.main.transform.localPosition;
        p.z = pt.z; // Make sure the camera bound is the same as the input pt's z-value
        Bounds camBounds = new Bounds(p, new Vector3(w, h, 2f));
                // The z-dimension is assumed to be some thickness, e.g., 2-units, to cover all objects in the scene
        return camBounds.Contains(pt);
    }

}
