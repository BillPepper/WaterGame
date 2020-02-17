using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;

    private bool isWalking = false;

    public void FixedUpdate()
    {
        if (this.isWalking)
        {
            this.transform.position = new Vector2(this.transform.position.x + speed * Time.fixedDeltaTime, this.transform.position.y);
        }
    }

    public bool SetIsWalking()
    {
        return this.isWalking;
    }

    public void SetIsWalking(bool state)
    {
        this.isWalking = state;
    }
}
