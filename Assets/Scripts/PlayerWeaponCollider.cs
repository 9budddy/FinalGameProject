using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeaponCollider : MonoBehaviour
{
    private bool sword, bow;
    private bool start = false;

    private Animator animator;
    [SerializeField] private GameState gameState;
    [SerializeField] private SpriteRenderer weaponSR;
    [SerializeField] private Animator weaponAnimator, overlayAnimator;
    void Start()
    {
        animator = GetComponent<Animator>();

        bow = false;
        sword = false;

        gameState.bow = false;
        gameState.sword = false;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword")
        {
            if (!sword)
            {
                sword = true;
                bow = false;

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
        }

        else if (collision.tag == "Bow")
        {
            if (!bow)
            {
                bow = true;
                sword = false;

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


    IEnumerator SetBow()
    {
        while (start)
        {
            yield return new WaitForSeconds(0.5f);
            animator.SetBool("bow", true);
            weaponAnimator.SetBool("bow", true);
            overlayAnimator.SetBool("bow", true);

            gameState.bow = true;
            gameState.sword = false;
            gameState.changeWeapon = true;
            weaponSR.enabled = true;

            start = false;
        }
    }

    IEnumerator SetSword()
    {
        while (start)
        {
            yield return new WaitForSeconds(0.5f);
            animator.SetBool("sword", true);
            weaponAnimator.SetBool("sword", true);
            overlayAnimator.SetBool("sword", true);

            gameState.bow = false;
            gameState.sword = true;
            gameState.changeWeapon = true;
            weaponSR.enabled = true;

            start = false;
        }
    }
}
