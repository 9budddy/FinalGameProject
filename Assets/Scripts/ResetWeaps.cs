using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWeaps : MonoBehaviour
{
    [SerializeField] GameState gameState;
    [SerializeField] SpriteRenderer weapon;
    [SerializeField] private Animator animator, weaponAnimator, overlayAnimator;
    void Start()
    {
        gameState.bow = false;
        gameState.sword = false;
        weapon.enabled = false;

        animator.SetBool("bow", false);
        animator.SetBool("sword", false);
        weaponAnimator.SetBool("bow", false);
        weaponAnimator.SetBool("sword", false);
        overlayAnimator.SetBool("bow", false);
        overlayAnimator.SetBool("sword", false);
    }
}
