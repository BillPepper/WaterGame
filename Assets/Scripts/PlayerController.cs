using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public int health = 5;

    private bool walking = false;
    private bool dead = false;
    private bool finished = false;
    private SpriteRenderer ComboBubble;

    public void Start()
    {
        this.ComboBubble = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void FixedUpdate()
    {
        if (this.walking)
        {
            this.transform.position = new Vector2(this.transform.position.x + speed * Time.fixedDeltaTime, this.transform.position.y);
        }

        Vector3 start = Vector3.zero;
        Vector3 direction = Vector3.forward;
        RaycastHit hit;
        if (Physics.Raycast(start, direction, out hit))
        {
            hit.collider.gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        string collisionObjTag = collision.gameObject.tag;

        if (collisionObjTag == "LevelEnd")
        {
            this.finished = true;
            Debug.Log("Player finished level");
        }

        if (collisionObjTag == "Enemy")
        {
            this.Hurt(1);
            Debug.Log("Ouch! " + this.health.ToString() + " lives remaining");
        }
    }

    private void Hurt(int h)
    {
        this.health -= h;
        if (this.health < 1)
        {
            this.dead = true;
            Debug.Log("Player died");
        }
    }

    public void ShowCombo()
    {
        this.ComboBubble.enabled = true;
    }

    public bool IsWalking()
    {
        return this.walking;
    }

    public void SetWalking(bool state)
    {
        this.walking = state;
    }

    public bool IsFinished()
    {
        return this.finished;
    }

    public bool IsDead()
    {
        return this.dead;
    }

    public int GetHealth()
    {
        return this.health;
    }
}
