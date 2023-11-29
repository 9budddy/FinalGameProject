using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private bool attack = false;

    private float speed = 10f;
    private int direction = 1;
    private Vector3 movement;

    private Rigidbody2D rb;
    private Animator animator;

    private PlayerState playerState;

    [SerializeField] private GameState gameState;
    [SerializeField] private Transform weaponTransform;
    [SerializeField] private Animator weaponAnimator, overlayAnimator;
    [SerializeField] private SpriteRenderer weaponSR, overlaySR;

    void Start()
    {

        gameState.changeWeapon = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    enum PlayerState
    {
        CHANGE = -1,
        SIDE = 0,
        UP = 1,
        DOWN = 2
    }

    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement = Vector3.zero;

        float wX = weaponTransform.localPosition.x;
        float wY = weaponTransform.localPosition.y;

        if (gameState.sword)
        {
            if (wX != -0.3)
            {
                weaponTransform.localPosition = new Vector3(0f, -0.3f, 0f);
            }
        }

        if (x > 0)
        {
            direction = -1;
            if (!attack)
            {
                transform.localScale = new Vector3(direction, 1, 1);
                if (gameState.bow && y == 0)
                {
                    if (wX != -0.6f || wY != -0.5f)
                    {
                        weaponTransform.localPosition = new Vector3(-0.6f, -0.5f, 0f);
                    }
                }
                playerState = PlayerState.SIDE;
            }
            movement += Vector3.right;

        }
        if (x < 0)
        {
            direction = 1;
            if (!attack)
            {
                transform.localScale = new Vector3(direction, 1, 1);

                playerState = PlayerState.SIDE;
            }

            movement += Vector3.left;

        }

        if (y > 0) 
        {
            if (!attack)
            {
                playerState = PlayerState.UP;
            }


            movement += Vector3.up;

        }

        if (y < 0)
        {
            if (!attack)
            {
                playerState = PlayerState.DOWN;
            }

            movement += Vector3.down;

        }


        //WEAPON CHANGE---
        if (gameState.changeWeapon)
        {
            playerState = PlayerState.CHANGE;

            animator.ResetTrigger("attacking");
            weaponAnimator.ResetTrigger("attacking");
            overlayAnimator.ResetTrigger("attacking");
            attack = false;

            //SET STATES---
            animator.SetInteger("state", (int)playerState);
            weaponAnimator.SetInteger("state", (int)playerState);
            overlayAnimator.SetInteger("state", (int)playerState);

            gameState.changeWeapon = false;
        }

        animator.SetInteger("state", (int)playerState);
        weaponAnimator.SetInteger("state", (int)playerState);
        overlayAnimator.SetInteger("state", (int)playerState);

        if ((int)playerState == 0)
        {
            if (gameState.bow && y == 0)
            {
                if (wX != -0.6f || wY != -0.5f)
                {
                    weaponTransform.localPosition = new Vector3(-0.6f, -0.5f, 0f);
                }
            }
        }
        if ((int)playerState == 1)
        {
            if (gameState.bow)
            {
                if (wX != 0.0f || wY != 0.5f)
                {
                    weaponTransform.localPosition = new Vector3(0f, 0.5f, 0f);
                }
            }
        }
        if ((int)playerState == 2)
        {
            if (gameState.bow)
            {
                if (wX != 0.0f || wY != -0.8f)
                {
                    weaponTransform.localPosition = new Vector3(0f, -0.8f, 0f);
                }
            }
        }

        //SET RUNNING---
        if (movement == Vector3.zero)
        {
            animator.SetBool("running", false);
        }
        else
        {
            animator.SetBool("running", true);
        }


        if ((gameState.bow || gameState.sword) && !attack)
        {

            if (y > 0)
            {
                overlaySR.enabled = false;
                weaponSR.sortingOrder = -1;
            }
            else if (y < 0 || x > 0 || x < 0)
            {

                overlaySR.enabled = true;
                weaponSR.sortingOrder = 1;
            }
        }


        if (Input.GetKey(KeyCode.Space))
        {
            if (!attack)
            {
                StartCoroutine(attackTimer());
            }
        }
        else
        {

            animator.ResetTrigger("attacking");
            weaponAnimator.ResetTrigger("attacking");
            overlayAnimator.ResetTrigger("attacking");
        }

        transform.position += movement * speed * Time.deltaTime;
    }

    IEnumerator attackTimer()
    {
        attack = true;
        while (attack)
        {
            animator.SetTrigger("attacking");
            weaponAnimator.SetTrigger("attacking");
            overlayAnimator.SetTrigger("attacking");
            yield return new WaitForSeconds(1.2f);
            attack = false;
        }
    }
}
