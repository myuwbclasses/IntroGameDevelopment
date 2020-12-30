using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Plane: Started");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateColor()
    {
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        Color c = s.color;
        const float delta = 0.01f;
        c.r -= delta;
        c.a -= delta;
        s.color = c;
        Debug.Log("Plane: Color = " + c);

        if (c.a <= 0.0f)
        {
            Sprite t = Resources.Load<Sprite>("Textures/Egg");   // File name with respect to "Resources/" folder
            s.sprite = t;
            s.color = Color.white;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Plane: OnTriggerEnter2D");
        UpdateColor();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Plane: OnTriggerStay2D");
        UpdateColor();
    }
}
