using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeaponCollider : MonoBehaviour
{
    private bool sword, bow;
    private bool start = false;
    private bool update = false;

    private Animator animator;
    [SerializeField] private GameState gameState;
    [SerializeField] private SpriteRenderer weaponSR;
    [SerializeField] private Animator weaponAnimator, overlayAnimator;
    void Start()
    {
        animator = GetComponent<Animator>();

        bow = false;
        sword = false;



        if (gameState.sword)
        {
            animator.SetBool("sword", true);
            weaponAnimator.SetBool("sword", true);
            overlayAnimator.SetBool("sword", true);
            animator.SetBool("switch", true);
            StartCoroutine(SwitchOff());
            weaponSR.enabled = true;
        }


        if (gameState.bow)
        {
            animator.SetBool("bow", true);
            weaponAnimator.SetBool("bow", true);
            overlayAnimator.SetBool("bow", true);
            animator.SetBool("switch", true);
            StartCoroutine(SwitchOff());
            weaponSR.enabled = true;
        }
    }

    IEnumerator SwitchOff()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("switch", false);
    }

    private void Update()
    {
        if (!gameState.attack && gameState.haltInput)
        {

            if (sword && !update)
            {
                update = true;
                gameState.canAttack = false;

                gameState.bow = false;
                gameState.sword = false;
                animator.SetBool("bow", false);
                animator.SetBool("sword", false);
                weaponAnimator.SetBool("bow", false);
                weaponAnimator.SetBool("sword", false);
                overlayAnimator.SetBool("bow", false);
                overlayAnimator.SetBool("sword", false);

                start = true;
                StartCoroutine(SetSword());
            }
            if (bow && !update)
            {
                update = true;
                gameState.canAttack = false;

                gameState.bow = false;
                gameState.sword = false;
                animator.SetBool("bow", false);
                animator.SetBool("sword", false);
                weaponAnimator.SetBool("bow", false);
                weaponAnimator.SetBool("sword", false);
                overlayAnimator.SetBool("bow", false);
                overlayAnimator.SetBool("sword", false);

                start = true;
                StartCoroutine(SetBow());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword")
        {
            if (!sword)
            {
                gameState.haltInput = true;
                sword = true;
                bow = false;
            }
        }

        else if (collision.tag == "Bow")
        {
            if (!bow)
            {
                gameState.haltInput = true;
                bow = true;
                sword = false;
            }
        }
    }


    IEnumerator SetBow()
    {
        while (start)
        {
            animator.SetBool("switch", true);
            weaponAnimator.SetBool("switch", true);
            overlayAnimator.SetBool("switch", true);
            animator.ResetTrigger("attacking");
            weaponAnimator.ResetTrigger("attacking");
            overlayAnimator.ResetTrigger("attacking");
            yield return new WaitForSeconds(0.2f);

            animator.SetBool("bow", true);
            weaponAnimator.SetBool("bow", true);
            overlayAnimator.SetBool("bow", true);

            yield return new WaitForSeconds(1f);

            gameState.bow = true;
            gameState.sword = false;
            weaponSR.enabled = true;

            start = false;

            animator.SetBool("switch", false);
            weaponAnimator.SetBool("switch", false);
            overlayAnimator.SetBool("switch", false);

            yield return new WaitForSeconds(0.2f);

            update = false;
            gameState.haltInput = false;
        }
    }

    IEnumerator SetSword()
    {
        while (start)
        {
            animator.SetBool("switch", true);
            weaponAnimator.SetBool("switch", true);
            overlayAnimator.SetBool("switch", true);
            animator.ResetTrigger("attacking");
            weaponAnimator.ResetTrigger("attacking");
            overlayAnimator.ResetTrigger("attacking");
            yield return new WaitForSeconds(0.2f);

            animator.SetBool("sword", true);
            weaponAnimator.SetBool("sword", true);
            overlayAnimator.SetBool("sword", true);

            yield return new WaitForSeconds(1f);

            gameState.bow = false;
            gameState.sword = true;
            weaponSR.enabled = true;

            start = false;

            animator.SetBool("switch", false);
            weaponAnimator.SetBool("switch", false);
            overlayAnimator.SetBool("switch", false);

            yield return new WaitForSeconds(0.2f);

            gameState.haltInput = false;
            update = false;
        }
    }
}
