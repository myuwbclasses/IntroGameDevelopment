using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{
    static private GreenArrowBehavior sGreenArrow = null;
    static public void SetGreenArrow(GreenArrowBehavior g) { sGreenArrow = g; }

    private const float kEggSpeed = 40f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += transform.up * (kEggSpeed * Time.smoothDeltaTime);
        if (!GameManager.sTheGlobalBehavior.IsInCameraBound(transform.localPosition))
        {
            Destroy(transform.gameObject);  // kills self
            sGreenArrow.OneLessEgg();
        }
    }
}
