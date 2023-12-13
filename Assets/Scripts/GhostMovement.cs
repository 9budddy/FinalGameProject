using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    [SerializeField] private GameState gameState;

    void Update()
    {
        Vector3 lastPos = gameState.ghosts.GetValueOrDefault(name);
        
        
        if (transform.position != lastPos)
        {
            gameState.ghosts.Remove(name);
            gameState.ghosts.Add(name, transform.position);
        }
    }
}
