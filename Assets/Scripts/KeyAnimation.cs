using UnityEngine;
using System.Collections;

public class KeyAnimation: MonoBehaviour
{

    public Animator animator;
    public KeyCode inputKey;
    public string animationName;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(inputKey))
        {
            animator.Play(animationName);
        }
    }
}

