using System.Collections.Generic;
using UnityEngine;

namespace Model.Creature
{
    [ExecuteAlways]
    public class CreatureFieldOfView : MonoBehaviour
    {
        public float fovRadius;
        [Range(0, 360)]
        public float fovAngle;

        public LayerMask targetMask;
        public LayerMask obstacleMask;

        public List<Transform> visibleTarget;
        
        private readonly Collider2D[] _targetInViewRadius = new Collider2D[100];

        public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal=false)
        {
            if (!angleIsGlobal) angleInDegrees += transform.eulerAngles.z;
            return new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0);
        }

        private void Update()
        {
            FindVisibleTargets();
        }

        private void FindVisibleTargets() 
        {
            visibleTarget.Clear();
            var size = Physics2D.OverlapCircleNonAlloc(transform.position, fovRadius, _targetInViewRadius, targetMask);
            for (var i = 0; i < size; i++)
            {
                var dirToTarget = (_targetInViewRadius[i].transform.position - transform.position).normalized;
                if (Vector3.Angle(transform.right, dirToTarget) > fovAngle / 2f) continue;
                var dist = Vector3.Distance(transform.position, _targetInViewRadius[i].transform.position);
                if (dist < 0.001f) continue;
                if (Physics2D.Raycast(transform.position + dirToTarget, dirToTarget, dist, obstacleMask)) continue;
                visibleTarget.Add(_targetInViewRadius[i].transform);
            }
        }
    }
}