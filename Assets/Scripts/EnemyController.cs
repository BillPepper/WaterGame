using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    private Rigidbody2D ownRigidbody;
    private SpriteRenderer ComboBubble;

    private bool alive;
    private void Start()
    {
        this.ownRigidbody = GetComponent<Rigidbody2D>();
        this.ComboBubble = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        this.alive = true;
    }

    private void Update()
    {
        if (this.transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.Die();
    }

    public void ShowCombo()
    {
        this.ComboBubble.enabled = true;
    }

    public void Die()
    {
        this.ComboBubble.enabled = false;
        this.alive = false;
        this.tag = "Dead";
        this.ownRigidbody.AddForce(new Vector2(-50, 100));
        this.ownRigidbody.gravityScale = 1;
    }

    public bool isAlive()
    {
        return this.alive;
    }
}
