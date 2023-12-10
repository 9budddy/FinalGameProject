using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private bool startAttack = true;
    private bool holdAttackingDir;
    private int currentPlayerState = 0;

    private float speed = 8f;
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
        holdAttackingDir = false;
        gameState.canAttack = false;
        gameState.attack = false;
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
        if (gameState.haltInput)
        {
            rb.velocity = Vector3.zero;
            //WEAPON CHANGE---
            if (gameState.changeWeapon)
            {
                playerState = PlayerState.CHANGE;

                animator.ResetTrigger("attacking");
                weaponAnimator.ResetTrigger("attacking");
                overlayAnimator.ResetTrigger("attacking");

                //SET STATES---
                animator.SetInteger("state", (int)playerState);
                weaponAnimator.SetInteger("state", (int)playerState);
                overlayAnimator.SetInteger("state", (int)playerState);

                gameState.changeWeapon = false;
                holdAttackingDir = false;
            }
        }
        else
        {
            if (!gameState.canAttack && startAttack)
            {
                StartCoroutine(CanAttack());
            }
            else
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
                    if (!gameState.attack && !holdAttackingDir)
                    {
                        transform.localScale = new Vector3(direction, 1, 1);
                        playerState = PlayerState.SIDE;
                    }
                    movement += Vector3.right;

                }
                if (x < 0)
                {
                    direction = 1;
                    if (!gameState.attack && !holdAttackingDir)
                    {
                        transform.localScale = new Vector3(direction, 1, 1);
                        playerState = PlayerState.SIDE;
                    }

                    movement += Vector3.left;

                }

                if (y > 0)
                {
                    if (!gameState.attack && !holdAttackingDir)
                    {
                        playerState = PlayerState.UP;
                    }


                    movement += Vector3.up;

                }

                if (y < 0)
                {
                    if (!gameState.attack && !holdAttackingDir)
                    {
                        playerState = PlayerState.DOWN;
                    }

                    movement += Vector3.down;

                }

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


                if ((gameState.bow || gameState.sword) && !gameState.attack)
                {

                    if (y > 0 && !holdAttackingDir)
                    {
                        overlaySR.enabled = false;
                        weaponSR.sortingOrder = -1;
                    }
                    else if ((y < 0 || x > 0 || x < 0) && !holdAttackingDir)
                    {

                        overlaySR.enabled = true;
                        weaponSR.sortingOrder = 1;
                    }
                }

                if (gameState.canAttack)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        if (!gameState.attack)
                        {
                            animator.SetInteger("state", currentPlayerState);
                            weaponAnimator.SetInteger("state", currentPlayerState);
                            overlayAnimator.SetInteger("state", currentPlayerState);

                            StartCoroutine(attackTimer());
                        }
                    }
                    else
                    {
                        currentPlayerState = (int)playerState;
                        holdAttackingDir = false;
                        animator.ResetTrigger("attacking");
                        weaponAnimator.ResetTrigger("attacking");
                        overlayAnimator.ResetTrigger("attacking");
                    }
                }

                animator.SetInteger("state", (int)playerState);
                weaponAnimator.SetInteger("state", (int)playerState);
                overlayAnimator.SetInteger("state", (int)playerState);

                rb.velocity = new Vector3(movement.x * speed, movement.y * speed);
            }
           
        }
        if (gameState.position != transform.position)
        {
            gameState.position = transform.position;
        }
    }

    IEnumerator CanAttack()
    {
        while (!gameState.canAttack)
        {
            startAttack = false;
            yield return new WaitForSeconds(0.5f);
            gameState.canAttack = true;
            startAttack = true;
        }
    }

    IEnumerator attackTimer()
    {
        gameState.attack = true;
        while (gameState.attack)
        {
            if (gameState.bow)
            {
                holdAttackingDir = true;
                animator.SetTrigger("attacking");
                weaponAnimator.SetTrigger("attacking");
                overlayAnimator.SetTrigger("attacking");
                yield return new WaitForSeconds(1.1f);
                gameState.attack = false;

            }
            else if (gameState.sword)
            {
                holdAttackingDir = true;
                animator.SetTrigger("attacking");
                weaponAnimator.SetTrigger("attacking");
                overlayAnimator.SetTrigger("attacking");
                yield return new WaitForSeconds(1.2f);
                gameState.attack = false;
            }
            else
            {
                holdAttackingDir = true;
                yield return new WaitForSeconds(0.5f);
                gameState.attack = false;
            }
        }
    }
}
