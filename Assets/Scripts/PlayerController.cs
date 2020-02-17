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

    public void FixedUpdate()
    {
        if (this.walking)
        {
            this.transform.position = new Vector2(this.transform.position.x + speed * Time.fixedDeltaTime, this.transform.position.y);
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
            this.hurt();
            Debug.Log("Ouch! " + this.health.ToString() + " lives remaining");
        }
    }

    private void hurt()
    {
        this.health--;
        if (this.health < 1)
        {
            this.dead = true;
            Debug.Log("Player died");
        }
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

    public int getHealth()
    {
        return this.health;
    }
}
