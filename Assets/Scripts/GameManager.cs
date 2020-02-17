using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController Player;

    private bool gameIsStarted;
    private bool gameIsLost;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            this.gameIsStarted = true;
            Player.SetIsWalking(true);
        }
    }
}
