using _Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleRotational : MonoBehaviour
{
    private int i;
    [SerializeField] private List<GameObject> pathPoints = new List<GameObject>();
    [SerializeField] private float speed = 5f;
    List<Vector3> paths;
    void Awake()
    {
        i = 0;
        paths = new List<Vector3>();

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
        if (Vector3.Distance(transform.position, paths[i]) <= 0.5f)
        {
            i += 1;
            if (i == paths.Count)
            {
                i = 0;
            }
        }
    }

    private void StartRotation()
    {
        transform.position = Vector3.MoveTowards(transform.position, paths[i], speed * Time.deltaTime);

    }
}
