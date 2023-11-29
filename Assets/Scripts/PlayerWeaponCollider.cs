using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponCollider : MonoBehaviour
{
    private bool sword, bow;

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

    
    private void OnTriggerStay2D(Collider2D collision)
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


                animator.SetBool("sword", true);
                weaponAnimator.SetBool("sword", true);
                overlayAnimator.SetBool("sword", true);


                gameState.bow = false;
                gameState.sword = true;
                gameState.changeWeapon = true;
                weaponSR.enabled = true;
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


                animator.SetBool("bow", true);
                weaponAnimator.SetBool("bow", true);
                overlayAnimator.SetBool("bow", true);


                gameState.bow = true;
                gameState.sword = false;
                gameState.changeWeapon = true;
                weaponSR.enabled = true;
            }
        }
    }
}
