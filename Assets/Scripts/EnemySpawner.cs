using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameState gameState;

    void Start()
    {
        StartCoroutine(BrainSpawner(10f));
    }

    IEnumerator BrainSpawner(float waitTime)
    {
        while (true)
        {




            yield return new WaitForSeconds(waitTime);
        }
    }
}
