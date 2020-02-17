using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.GameOver();
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            this.StartGame();
        }
        if (Player.GetIsFinished() || Player.GetIsDead()) // seperate these
        {
            this.GameOver();
        }
    }

    void StartGame()
    {
        this.gameIsStarted = true;
        Player.SetIsWalking(true);
    }

    void GameOver()
    {
        this.gameIsStarted = false;
        SceneManager.LoadScene("GameOver");
    }
}
