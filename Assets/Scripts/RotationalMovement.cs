using _Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalMovement : MonoBehaviour
{
    private int i;
    private List<GameObject> pathPoints;
    List<Vector3> paths;
    void Awake()
    {
        i = 0;
        paths = new List<Vector3>();
        pathPoints = new List<GameObject>();

        GameObject o1 = GameObject.Find("Slerpy Slerp");
        GameObject o2 = GameObject.Find("Slerpy Slerp1");
        GameObject o3 = GameObject.Find("Slerpy Slerp2");

        pathPoints.Add(o1);
        pathPoints.Add(o2);
        pathPoints.Add(o3);

        foreach (var pathPoint in pathPoints)
        {
            var slerp = pathPoint.GetComponent<SlerpySlerp>();
            foreach (var point in slerp.EvaluateSlerpPoints(slerp._start.position, slerp._end.position, slerp._center.position, slerp._count))
            {
                paths.Add(point);
            }
        }
    }

    private void Update()
    {
        StartRotation();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, paths[i]) <= .05f)
        {
            i += 1;
            if (i == paths.Count)
            {
                Destroy(gameObject);
            }
        }
    }

    private void StartRotation()
    {
        transform.position = Vector3.MoveTowards(transform.position, paths[i], 5f * Time.deltaTime);

    }
}
