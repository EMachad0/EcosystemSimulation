using UnityEngine;

namespace Model.Creature
{
    public class CreatureMovement : MonoBehaviour
    {
        public bool isRunning;
        public float runCoefficient;
        public float walkSpeed;
        [HideInInspector] public Vector2 target;

        private Vector3 _lastPosition;
        
        private void Awake()
        {
            target = transform.position;
        }

        private void Start()
        {
            _lastPosition = transform.position;
        }

        public void LookAtTarget()
        {
            var difference = (Vector3) target - transform.position;
            var rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        }

        public void Move()
        {
            var position = transform.position;
            _lastPosition = position;
            var maxDistanceDelta = (isRunning ? walkSpeed * runCoefficient : walkSpeed) * Time.deltaTime; 
            transform.position = Vector3.MoveTowards(position, target, maxDistanceDelta);
        }

        public bool IsMoving()
        {
            return Vector3.Distance(_lastPosition, transform.position) > 0.001f;
        }
    }
}