using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ColorBlock : MonoBehaviour
{
    [SerializeField, Range(0.05f, 1f)] public float ChangeRate = 0.5f;

    private const string kHeroName = "Hero - Green";
    
    private Coroutine mColorChanging = null;  // to signify that hero is currently undergoing color changes

    // Start is called before the first frame update
    public ColorsForBlocks mColorMagic;

    void Start()
    {
        // initialize color
        GetComponent<SpriteRenderer>().color = mColorMagic.InitColor(); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("WhiteMagic TriggerEnter: " + other.gameObject.name);
        EnterColorChangeMode(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("WhiteMagic TriggerExit: " + other.gameObject.name);
        ExitColorChangeMode();
    }

    private void EnterColorChangeMode(GameObject hero) {
        if (hero.name == kHeroName) {  // only enter if collide with hero
            // make sure to clean up coroutine ...
            if (mColorChanging != null) 
                ExitColorChangeMode();

            IEnumerator rightFunc = ColorChangeFromRight(); // To show: variable of function pointer type
            if (hero.transform.localPosition.x > transform.localPosition.x)  // assume coming from the right
                mColorChanging = StartCoroutine(rightFunc);
            else
                mColorChanging = StartCoroutine(ColorChangeFromLeft());
        }
    }

    private void ExitColorChangeMode() {
        if (mColorChanging != null) {
            StopCoroutine(mColorChanging);
                    // Also, check out StopAllCoroutines();
            mColorChanging = null;
            GetComponent<SpriteRenderer>().color = mColorMagic.InitColor();
        }
    }

    // === Support for coroutine
    private IEnumerator ColorChangeFromLeft() {
        int count = 0;
        while (count < mColorMagic.NumInSequence()) {
            GetComponent<SpriteRenderer>().color = mColorMagic.ColorSequence(count);
            yield return new WaitForSeconds(ChangeRate);
                // alternate: to be called again immediately at next frame
                //    yield return null; 
            // <-- Next invocation will begin here 
            Debug.Log("Left CoRoutine: start again count=" + count + " Color=" + GetComponent<SpriteRenderer>().color);
            count++;
        }
        ExitColorChangeMode();
    }

    private IEnumerator ColorChangeFromRight() {
        int count = 0;
        while (count < mColorMagic.NumInSequence()) {
            GetComponent<SpriteRenderer>().color = mColorMagic.NextBlinkColor(count);
            
            yield return new WaitForSeconds(ChangeRate);
                // alternate: to be called again immediately at next frame
                //    yield return null; 
            // <-- Next invocation will begin here 
            Debug.Log("Right CoRoutine: start again count=" + count + " Color=" + GetComponent<SpriteRenderer>().color);
            count++;
        }
        ExitColorChangeMode();
    }
}
