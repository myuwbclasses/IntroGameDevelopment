using UnityEngine;

// to show up in the Create-Menu as: MagicBlock
[CreateAssetMenu(fileName="ColorsForBlocks", menuName="Create colors for Blocks")]

public class ColorsForBlocks : ScriptableObject
{
    [SerializeField] private Color mInitColor = Color.white;
    [SerializeField] private Color[] mColorSequence = { 
                        new Color(1f, 0f, 0f, 1f), 
                        new Color(1f, 1f, 0f, 1f),
                        new Color(0.8f, 0.8f, 0.8f, 1f),
                        new Color(0f, 1f, 1f, 1f),
                        new Color(0f, 0f, 1f, 1f),
                        new Color(0f, 0f, 0f, 1f),
                        new Color(1f, 1f, 1f, 1.0f)};

    [SerializeField] private Color[] mColorBlink = {Color.white, Color.black};

    // Accessors to the data
    public Color InitColor() {
        return mInitColor;
    }

    // When working with sequence
    public int NumInSequence() { return mColorSequence.Length; }   
    public Color ColorSequence(int index) {
        return mColorSequence[index];
    }

    public Color NextBlinkColor(int index) {
        return mColorBlink[index%2];

    }

}
