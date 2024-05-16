using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UI;  // Required to work with UI, e.g., Text

public class GameManager : MonoBehaviour
{
    public static GameManager sTheGlobalBehavior = null; // Single pattern


    public GreenArrowBehavior mHero = null;  // must set in the editor


    // Start is called before the first frame update
    void Start()
    {
        GameManager.sTheGlobalBehavior = this;  // Singleton pattern
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OneMorePlane() {
        GameObject p = Instantiate(Resources.Load("Plane") as GameObject); // Prefab MUST BE locaed in Resources/Prefab folder!
        p.transform.localPosition = new Vector3(0f, 0f, 0);
    }
}
