using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    private SpriteRenderer ComboBubble;
    public KeyCode[] combos;
    private Animator animator;

    private bool alive;
    private void Start()
    {
        this.ComboBubble = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        this.alive = true;
        this.animator = GetComponent<Animator>();
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
        animator.SetTrigger("death");
        this.ComboBubble.enabled = false;
        this.alive = false;
        this.tag = "Dead";
    }

    public KeyCode[] GetCombo()
    {
        return this.combos;
    }

    public bool isAlive()
    {
        return this.alive;
    }


}
