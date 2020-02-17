using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text ownText;

    private int score;
    void Start()
    {
        this.ownText = GetComponent<Text>();
        this.score = 0;
    }

    void Update()
    {
        this.ownText.text = this.score.ToString();
    }

    public void addScore(int s)
    {
        this.score += s;
    }
}
