using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewLevelGameManager : MonoBehaviour
{
    public TMP_Text mGameStateEcho = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mGameStateEcho.text = "New Level: " + GameState.sGameState.EchoGameState();
    }
}
