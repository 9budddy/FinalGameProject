using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamageCollider : MonoBehaviour
{
    [SerializeField] GameState gameState;
    float health, maxHealth;
    float regenTimer = 0.0f;

    private bool blackHole = true; 
    [SerializeField] private FloatingHealth floatingHealth;

    void Start()
    {
        if (gameState.bow)
        {
            health = 10f;
            maxHealth = 10f;
        }
        else if (gameState.sword)
        {
            health = 18f;
            maxHealth = 18f;
        }
        else
        {
            health = 10f;
            maxHealth = 10f;
        }
        floatingHealth.UpdateHealthBar(health, maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BrainShot")
        {
            if (gameState.bow)
            {
                health -= 1f;
            }
            else if (gameState.sword)
            {
                health -= 0.5f;
            }
            else
            {
                health -= 2f;
            }
            floatingHealth.UpdateHealthBar(health, maxHealth);

            if (health <= 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
            Destroy(collision.gameObject);

        }
        if (collision.tag == "GhostShot")
        {
            if (gameState.bow)
            {
                health -= 2f;
            }
            else if (gameState.sword)
            {
                health -= 1f;
            }
            else
            {
                health -= 3f;
            }

            floatingHealth.UpdateHealthBar(health, maxHealth);

            if (health <= 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
            Destroy(collision.gameObject);

        }

        if (collision.tag == "FireBall")
        {
            if (gameState.bow)
            {
                health -= 4f;
            }
            else if (gameState.sword)
            {
                health -= 2f;
            }
            else
            {
                health -= 5f;
            }
            floatingHealth.UpdateHealthBar(health, maxHealth);
            if (health <= 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
            Destroy(collision.gameObject);
        }
        if (collision.tag == "BlackHole" && blackHole)
        {
            blackHole = false;
            StartCoroutine(BlackHoldDamage());
            if (gameState.bow)
            {
                health -= 3f;
            }
            else if (gameState.sword)
            {
                health -= 2f;
            }
            else
            {
                health -= 5f;
            }
            floatingHealth.UpdateHealthBar(health, maxHealth);
            if (health <= 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    IEnumerator BlackHoldDamage()
    {
        yield return new WaitForSeconds(2f);
        blackHole = true;
    }

    private void Update()
    {
        regenTimer += Time.deltaTime;

        if (gameState.bow)
        {
            if (regenTimer >= 15f)
            {
                regenTimer = 0.0f;
                if (health < maxHealth)
                {
                    health += 0.5f;
                    floatingHealth.UpdateHealthBar(health, maxHealth);
                }
            }
        }

        else if (gameState.sword)
        {
            if (regenTimer >= 8f)
            {
                regenTimer = 0.0f;
                if (health < maxHealth - 1f)
                {
                    health += 1f;
                    floatingHealth.UpdateHealthBar(health, maxHealth);
                }
            }
        }
    }
}
