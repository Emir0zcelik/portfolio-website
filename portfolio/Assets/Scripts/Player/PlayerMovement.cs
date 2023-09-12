using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private float moveSpeed = 7f;

    private float dirX = 0f;
    private float dirY = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", dirX);
        animator.SetFloat("Vertical", dirY);


        if (dirX != 0 || dirY != 0)
            animator.SetBool("isWalk", true);
        else
            animator.SetBool("isWalk", false);

        rb.velocity = new Vector2(dirX * moveSpeed, dirY * moveSpeed);
    }
}
