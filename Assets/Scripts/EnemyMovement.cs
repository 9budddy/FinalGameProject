using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float timer = 1.0f;

    private float speed;
    [SerializeField] private float screenBorder;

    private Rigidbody2D rb;
    private PlayerAwarenessController playerAwarenessController;
    private Vector2 targetDirection;
    private float changeDirectionCooldown;
    private Camera cam;

    private void Start()
    {
        speed = 0.2f;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAwarenessController = GetComponent<PlayerAwarenessController>();
        targetDirection = transform.up;
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
        HandleEnemyOffScreen();
    }

    private void HandleRandomDirectionChange()
    {
        changeDirectionCooldown -= Time.deltaTime;

        if (changeDirectionCooldown <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            targetDirection = rotation * targetDirection;

            changeDirectionCooldown = Random.Range(1f, 5f);
        }
    }

    private void HandlePlayerTargeting()
    {
        float maxSpeed = 4.5f;
        float minSpeed = 0.2f;
        if (playerAwarenessController.AwareOfPlayer)
        {
            timer = 0.0f;
            if (speed == minSpeed)
            {
                speed = maxSpeed;
            }

            targetDirection = playerAwarenessController.DirectionToPlayer;
        }
        else
        {
            if (timer > 0.3f)
            {
                if (speed == maxSpeed)
                {
                    speed = minSpeed;
                }
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

    private void HandleEnemyOffScreen()
    {
        //-20y - 60y
        //-20x - 50x
        Vector2 screenPosition = transform.position;

        float maxX = 50f;
        float minX = -20f;
        float maxY = 60f;
        float minY = -20f;

        if ((screenPosition.x < minX - screenBorder && targetDirection.x < 0) ||
            (screenPosition.x > maxX + screenBorder && targetDirection.x > 0))
        {
            targetDirection = new Vector2(-targetDirection.x, targetDirection.y);
        }

        if ((screenPosition.y < minY + screenBorder && targetDirection.y < 0) ||
            (screenPosition.y > maxY - screenBorder && targetDirection.y > 0))
        {
            targetDirection = new Vector2(targetDirection.x, -targetDirection.y);
        }
    }


    private void SetVelocity()
    {
        rb.velocity = targetDirection * speed;
    }
}
