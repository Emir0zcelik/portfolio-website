using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private MovementJoystick movementJoystick;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameObject MobilePanel;
    [SerializeField] private GameObject Camera;

    private float dirX = 0f;
    private float dirY = 0f;

    private bool isMobile;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isMobile = WebGLBrowserCheck.IsMobileBrowser();

        if (isMobile)
        {
            Camera.GetComponent<Camera>().orthographicSize = 7.5f;
            MobilePanel.SetActive(true);
        }

    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");

        if (isMobile)
        {
            if (movementJoystick.joystickVec.y != 0)
            {
                animator.SetFloat("Horizontal", movementJoystick.joystickVec.x);
                animator.SetFloat("Vertical", movementJoystick.joystickVec.y);
                rb.velocity = new Vector2(movementJoystick.joystickVec.x * moveSpeed, movementJoystick.joystickVec.y * moveSpeed);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            animator.SetFloat("Horizontal", dirX);
            animator.SetFloat("Vertical", dirY);
            rb.velocity = new Vector2(dirX * moveSpeed, dirY * moveSpeed);
        }

        if (dirX != 0 || dirY != 0 || movementJoystick.joystickVec.x != 0 || movementJoystick.joystickVec.y != 0)
            animator.SetBool("isWalk", true);
        else
            animator.SetBool("isWalk", false);
    }

}
