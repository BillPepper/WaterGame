using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DbgEnemyCount : MonoBehaviour
{
    private Text ownText;

    private void Start()
    {
        this.ownText = GetComponent<Text>();
        this.setText(-1);
    }
    void Update()
    {
        this.setText(getEnemyCount());
    }

    int getEnemyCount()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        return enemies.Length;
    }

    void setText(int c)
    {
        this.ownText.text = "EnemyCount: " + c;
    }
}
