using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewLevelGameManager : MonoBehaviour
{
    public Text GameStateEcho = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameStateEcho.text = "New Level: " + GameState.sGameState.EchoGameState();
    }
}
