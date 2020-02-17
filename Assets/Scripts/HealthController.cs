using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private int health;
    private Text ownText;

    public void Start()
    {
        ownText = GetComponent<Text>();
    }

    public void Update()
    {
        this.ownText.text = "Health: " + this.health.ToString();
    }

    public void SetHealth(int h)
    {
        this.health = h;
    }
}
