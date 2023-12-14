using _Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InvulnerableAttack : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject fire;

    private bool fireSpawned = false;

    private void Start()
    {
        gameState.bossInvulnerable = true;
        fireSpawned = false;
    }

    void Update()
    {
        if (!fireSpawned && gameState.bossInvulnerable)
        {
            fireSpawned = true;
            StartCoroutine(SpawnFire());
        }
    }

    IEnumerator SpawnFire()
    {
        Instantiate(fire, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        fireSpawned = false;
        
    }
}
