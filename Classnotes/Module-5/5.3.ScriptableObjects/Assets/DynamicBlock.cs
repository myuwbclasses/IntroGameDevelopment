using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBlock : MonoBehaviour
{
    private const string kHeroName = "Hero - Green";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Myname=[" + gameObject.name + "] Collision Enter: " + other.gameObject.name);
        
        if (other.gameObject.name != kHeroName)
            return;  // only when collide with the hero
        
        GameObject g = new GameObject();
        g.transform.localPosition = other.transform.localPosition;
        g.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        g.AddComponent<SpriteRenderer>();
        g.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Egg");
        g.AddComponent<BoxCollider2D>();
        g.GetComponent<BoxCollider2D>().isTrigger = true;
        g.AddComponent<ColorBlock>();
        g.GetComponent<ColorBlock>().mColorMagic =  Resources.Load<ColorsForBlocks>("ColorBlocks/RedBlock");
    }
}
