using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public int health = 5;

    private bool isWalking = false;
    private bool isDead = false;
    private bool isFinished = false;

    public void FixedUpdate()
    {
        if (this.isWalking)
        {
            this.transform.position = new Vector2(this.transform.position.x + speed * Time.fixedDeltaTime, this.transform.position.y);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        string collisionObjTag = collision.gameObject.tag;

        if (collisionObjTag == "LevelEnd")
        {
            this.isFinished = true;
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
        if (health < 1)
        {
            this.isDead = true;
            Debug.Log("Player died");
        }
    }

    public bool GetIsWalking()
    {
        return this.isWalking;
    }

    public void SetIsWalking(bool state)
    {
        this.isWalking = state;
    }

    public bool GetIsFinished()
    {
        return this.isFinished;
    }

    public bool GetIsDead()
    {
        return this.isDead;
    }
}
