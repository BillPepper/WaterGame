using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    private Rigidbody2D ownRigidbody;
    private BoxCollider2D ownBoxCollider;

    private bool alive;
    private void Start()
    {
        this.ownRigidbody = GetComponent<Rigidbody2D>();
        this.ownBoxCollider = GetComponent<BoxCollider2D>();
        this.alive = true;
    }

    private void Update()
    {
        if (this.transform.position.y < -10)
        {
            Debug.Log("Destroyed enemy");
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.Die();
    }

    public void Die()
    {
        Debug.Log("Enemy" + this.name + " died");
        this.alive = false;
        this.tag = "Dead";
        this.ownRigidbody.AddForce(new Vector2(50, 100));
        this.ownRigidbody.gravityScale = 1;
    }

    public bool isAlive()
    {
        return this.alive;
    }
}
