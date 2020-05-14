using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public int health = 5;
    public float perception = 8f;

    private bool walking = false;
    private bool dead = false;
    private bool finished = false;
    private SpriteRenderer ComboBubble;
    public Animator animator;

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

        RaycastHit2D hitInfo = Physics2D.Raycast(new Vector2(this.transform.position.x + 0.7f, this.transform.position.y - 0.5f), this.transform.right, this.perception);

        // this triggers all over, not cool
        this.ShowCombo(!!hitInfo);

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
        animator.SetTrigger("hurt");
        this.health -= h;
        if (this.health < 1)
        {
            this.dead = true;
            Debug.Log("Player died");
        }
    }

    public void ShowCombo(bool s)
    {
        // this should not be set by bool, cause it is not in enemy controller
        // this.ComboBubble.enabled = s;
    }

    public bool IsWalking()
    {
        return this.walking;
    }

    public void SetWalking(bool state)
    {
        this.walking = state;
        animator.SetBool("isWalking", state);
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
