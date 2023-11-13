using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    private float speed = 10f;
    private int direction = 1;
    private Vector3 movement;

    private Rigidbody2D rb;
    private Animator animator;

    private PlayerState playerState;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    enum PlayerState
    {
        SIDE = 0,
        UP = 1,
        DOWN = 2
    }

    void Update()
    {
        movement = Vector3.zero;


        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            direction = -1;
            transform.localScale = new Vector3(direction, 1, 1);

            movement += Vector3.right;
            playerState = PlayerState.SIDE;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            direction = 1;
            transform.localScale = new Vector3(direction, 1, 1);

            movement += Vector3.left;
            playerState = PlayerState.SIDE;
        }

        if (Input.GetAxisRaw("Vertical") > 0) 
        {
            movement += Vector3.up;
            playerState = PlayerState.UP;
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            movement += Vector3.down;
            playerState = PlayerState.DOWN;
        }

        if (movement == Vector3.zero)
        {
            animator.SetInteger("state", (int)playerState);
            animator.SetBool("running", false);
        }
        else
        {
            animator.SetInteger("state", (int)playerState);
            animator.SetBool("running", true);
        }

        transform.position += movement * speed * Time.deltaTime;
    }
}
