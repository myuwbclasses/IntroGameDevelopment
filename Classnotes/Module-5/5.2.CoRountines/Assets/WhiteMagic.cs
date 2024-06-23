using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class WhiteMagic : MonoBehaviour
{
    [SerializeField, Range(0.05f, 1f)] public float ChangeRate = 0.5f;
    private const string kHeroName = "Hero - Green";
    // Assuming to be on the White object
    private Coroutine mHeroChanging = null;  // to signify that hero is currently undergoing color changes
    private Color[] mHeroColors = { new Color(1f, 0f, 0f, 1f), 
                                    new Color(1f, 1f, 0f, 1f),
                                    new Color(1f, 1f, 1f, 1f),
                                    new Color(0f, 1f, 1f, 1f),
                                    new Color(0f, 0f, 1f, 1f),
                                    new Color(0f, 0f, 0f, 1f),
                                    new Color(0.2f, 0.94f, 0.34f, 1.0f)};

    // Start is called before the first frame update
    void Start()
    {
        // Properly initialize hero color
        GameObject.Find(kHeroName).GetComponent<SpriteRenderer>().color = mHeroColors[mHeroColors.Length-1];
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            GameObject.Find(kHeroName).GetComponent<SpriteRenderer>().color = mHeroColors[0];
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            GameObject.Find(kHeroName).GetComponent<SpriteRenderer>().color = mHeroColors[2];
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("WhiteMagic TriggerEnter:" + other.gameObject.name);
        if (other.gameObject.name == kHeroName) {
            // check to make sure if CoRoutine already running
            if (mHeroChanging != null) 
                ColorChangeDone(other.gameObject); // stop the current running

            mHeroChanging = StartCoroutine(HeroColorChange(other.gameObject)); 
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("WhiteMagic TriggerExit:" + other.gameObject.name);
        if (other.gameObject.name == kHeroName) {
            // make sure to clean up coroutine ...
            if (mHeroChanging != null) 
                ColorChangeDone(other.gameObject);
        }
    }

    // === Support for coroutine
    private IEnumerator HeroColorChange(GameObject hero) {
        int count = 0;
        while (count < mHeroColors.Length) {
            hero.GetComponent<SpriteRenderer>().color = mHeroColors[count];
            yield return new WaitForSeconds(ChangeRate);
                // alternate: to be called again immediately at next frame
                //    yield return null; 
            // <-- Next invocation will begin here 
            Debug.Log("CoRoutine: start again count=" + count + " Color=" + hero.GetComponent<Renderer>().material.color);
            count += 1;
        }
        ColorChangeDone(hero);
    }

    void ColorChangeDone(GameObject hero) {
        if (mHeroChanging != null) {
            StopCoroutine(mHeroChanging);
                    // Also, check out StopAllCoroutines();
            mHeroChanging = null;
            hero.GetComponent<SpriteRenderer>().color = mHeroColors[mHeroColors.Length-1];
        }
    }


}
