using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts {
    public class SlerpySlerp : MonoBehaviour {
        [SerializeField] public Transform _start, _center, _end;
        [SerializeField] public int _count = 15;

        private void OnDrawGizmos() {
            foreach (var point in EvaluateSlerpPoints(_start.position, _end.position, _center.position,_count)) {
                Gizmos.DrawSphere(point, 0.1f);
            }

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_center.position, 0.2f);
        }

        public IEnumerable<Vector3> EvaluateSlerpPoints(Vector3 start, Vector3 end, Vector3 center,int count = 10) {
            var startRelativeCenter = start - center;
            var endRelativeCenter = end - center;

            var f = 1f / count;

            for (var i = 0f; i < 1 + f; i += f) {
                yield return Vector3.Slerp(startRelativeCenter, endRelativeCenter, i) + center;
            }
        }
    }
}