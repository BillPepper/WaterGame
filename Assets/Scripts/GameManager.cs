using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerController Player;
    public HealthController Health;
    public ScoreController Score;

    // DEBUG
    public GameObject closestEnemyText;

    private GameObject NextEnemy;
    private EnemyController NextEnemyController;

    private bool gameIsStarted;
    private bool gameIsLost;

    void Start()
    {
        this.UpdateHealth();
        
    }

    void Update()
    {
        this.UpdateHealth();

        if (this.NextEnemy)
        {
            NextEnemyController = NextEnemy.GetComponent<EnemyController>();
            if (!this.NextEnemyController.isAlive())
            {
                this.Score.addScore(100); // should not score when player was hit
                this.NextEnemy = null;
            }
        }

        if (!this.NextEnemy && this.GetEnemyCount() > 0)
        {
            this.NextEnemy = FindClosestEnemy();
            this.closestEnemyText.GetComponent<Text>().text = NextEnemy.name;
        }

        if (Player.GetIsFinished() || Player.GetIsDead()) // seperate these
        {
            this.GameOver();
        }

        this.handleInputs();
    }

    void handleInputs() { 
        if (Input.GetKeyDown(KeyCode.K) && NextEnemy)
        {
            NextEnemy.GetComponent<EnemyController>().Die();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.GameOver();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.StartGame();
        }
    }

    int GetEnemyCount()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    GameObject FindClosestEnemy()
    {
        Debug.Log("searching nearest enemy");

        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = Player.GetComponent<Transform>().position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    void UpdateHealth()
    {
        Health.SetHealth(Player.getHealth());
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
