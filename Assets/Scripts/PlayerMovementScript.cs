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


        if (x > 0)
        {
            direction = -1;
            if (!attack)
            {
                transform.localScale = new Vector3(direction, 1, 1);
            }
            movement += Vector3.right;
            playerState = PlayerState.SIDE;
        }
        if (x < 0)
        {
            direction = 1;
            if (!attack)
            {
                transform.localScale = new Vector3(direction, 1, 1);
            }

            movement += Vector3.left;
            playerState = PlayerState.SIDE;
        }

        if (y > 0) 
        {

            movement += Vector3.up;
            playerState = PlayerState.UP;
        }

        if (y < 0)
        {
            movement += Vector3.down;
            playerState = PlayerState.DOWN;
        }


        //WEAPON CHANGE---
        if (gameState.changeWeapon)
        {
            playerState = PlayerState.CHANGE;


            //SET STATES---
            animator.SetInteger("state", (int)playerState);
            weaponAnimator.SetInteger("state", (int)playerState);
            overlayAnimator.SetInteger("state", (int)playerState);

            gameState.changeWeapon = false;
        }

        animator.SetInteger("state", (int)playerState);
        weaponAnimator.SetInteger("state", (int)playerState);
        overlayAnimator.SetInteger("state", (int)playerState);

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
