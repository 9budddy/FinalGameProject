using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }
    private Vector2 enemyToPlayerVector;

    [SerializeField] private float minPlayerAwarenessDistance;
    [SerializeField] private float maxPlayerAwarenessDistance;

    [SerializeField] private GameState gameState;

    // Update is called once per frame
    private void FixedUpdate()
    {
        enemyToPlayerVector = gameState.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;
    }

    void Update()
    {
        

        if (enemyToPlayerVector.magnitude <= maxPlayerAwarenessDistance && enemyToPlayerVector.magnitude > minPlayerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
