using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour
{
    [SerializeField] List<GameObject> brainShot1;
    [SerializeField] List<GameObject> brainCannon;
    [SerializeField] List<GameObject> ghostShot;
    [SerializeField] List<GameObject> blackHole1;
    [SerializeField] List<GameObject> blackHoleCannon;

    [SerializeField] GameState gameState;
    void Start()
    {
        StartCoroutine(SpawnShots());
    }

    IEnumerator SpawnShots()
    {
        yield return new WaitForSeconds(5f);
        while (true)
        {
            StartCoroutine(SpawnBrainShot1());
            yield return new WaitForSeconds(3f);
            StartCoroutine(SpawnGhostShot1());
            yield return new WaitForSeconds(3f);
            gameState.bossInvulnerable = false;
            yield return new WaitForSeconds(6f);
            gameState.bossInvulnerable = true;
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator SpawnBrainShot1()
    {
        for(int i = 0; i < brainShot1.Count; i++)
        {
            if (i > 11)
            {
                Instantiate(brainShot1[i], brainShot1[i].transform.position, Quaternion.Euler(0,0,90f));
            }
            else
            {
                Instantiate(brainShot1[i], brainShot1[i].transform.position, Quaternion.identity);
            }
            
        }

        yield return new WaitForSeconds(0f);
    }

    IEnumerator SpawnGhostShot1()
    {
        for (int i = 0; i < ghostShot.Count; i++)
        {
            if (i > 7)
            {
                Instantiate(ghostShot[i], ghostShot[i].transform.position, Quaternion.Euler(0, 0, 90f));
            }
            else
            {
                Instantiate(ghostShot[i], ghostShot[i].transform.position, Quaternion.identity);
            }

        }

        yield return new WaitForSeconds(0f);
    }
}
