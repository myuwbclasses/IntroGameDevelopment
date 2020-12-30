using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderWithEcho : MonoBehaviour
{
    public string mLabelText = "Label Text:";
    public Text mEcho = null;
    public Slider mSlider = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(mEcho != null);
        Debug.Assert(mSlider != null);
    }

    // Update is called once per frame
    void Update()
    {
        mEcho.text = mLabelText + mSlider.value.ToString();
    }

    public float value() { return mSlider.value; }
}
