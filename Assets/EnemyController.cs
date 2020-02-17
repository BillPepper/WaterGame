using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    private Rigidbody2D ownRigidbody;
    private BoxCollider2D ownBoxCollider;
    private void Start()
    {
        this.ownRigidbody = GetComponent<Rigidbody2D>();
        this.ownBoxCollider = GetComponent<BoxCollider2D>();
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
        // when the player collides with the enemy, it does not die but deactivates
        this.Deactivate(); 
    }

    void Deactivate()
    {
        ownBoxCollider.enabled = false;
    }

    public void Die()
    {
        Debug.Log("Enemy" + this.name + " died");
        this.ownRigidbody.AddForce(new Vector2(500, 100));
        this.ownRigidbody.gravityScale = 1;
    }
}
