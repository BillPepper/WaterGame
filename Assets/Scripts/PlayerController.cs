using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;

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
        Debug.Log("Collided: " + collisionObjTag);

        if (collisionObjTag == "LevelEnd")
        {
            this.isFinished = true;
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
}
