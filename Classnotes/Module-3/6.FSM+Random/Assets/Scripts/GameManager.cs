using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject aPlane = Resources.Load<GameObject>("Prefabs/Plane");  // 
        for (int x = -9; x < 10; x+=2)
            for(int y = -9; y <10; y+=2)
            {
                GameObject g = Instantiate(aPlane);
                g.transform.position = new Vector3(x, y, 0);
                g.transform.localScale = new Vector3(0.45f, 0.45f, 1f);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
