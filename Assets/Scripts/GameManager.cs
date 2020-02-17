using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController Player;
    public HealthController Health;

    private GameObject NextEnemy;

    private bool gameIsStarted;
    private bool gameIsLost;

    void Start()
    {
        this.UpdateHealth();
    }

    void Update()
    {
        this.UpdateHealth();

        if (!this.NextEnemy)
        {
            this.NextEnemy = FindClosestEnemy();
        }

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

        if (Input.GetKeyDown(KeyCode.K))
        {
            NextEnemy.GetComponent<EnemyController>().Die();
        }
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
        Debug.Log("nearest enemy is " + closest.name);
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
