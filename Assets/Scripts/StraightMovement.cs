using _Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovement : MonoBehaviour
{
    private int i;
    [SerializeField] private Vector3 end;
    [SerializeField] private float speed = 10;

    private void Update()
    {
        StartRotation();
    }

    private void FixedUpdate()
    {
        
        if (Vector3.Distance(transform.position, end) <= .5f)
        {
            Destroy(gameObject);
        }
    }

    private void StartRotation()
    {
        transform.position = Vector3.MoveTowards(transform.position, end, speed * Time.deltaTime);
    }
}
