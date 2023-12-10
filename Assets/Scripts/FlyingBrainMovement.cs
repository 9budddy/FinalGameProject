using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBrainMovement : MonoBehaviour
{
    [SerializeField] private GameState gameState;

    void Update()
    {
        Vector3 lastPos = gameState.flyingbrains.GetValueOrDefault(name);
        if (transform.position != lastPos)
        {
            gameState.flyingbrains.Remove(name);
            gameState.flyingbrains.Add(name, transform.position);
        }
    }


}
