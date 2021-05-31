using System.Collections;
using Abstract;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Model.Creature.CreatureFSM
{
    public class RoamState : BaseFsm
    {
        public float roamInterval;
        public float roamDistance;
    
        private CreatureMovement _movement;
        private Coroutine _coroutine;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            _movement = gameObject.GetComponent<CreatureMovement>();
            _movement.isRunning = false;

            _coroutine = _movement.StartCoroutine(GetRandomTarget(roamInterval));
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _movement.Move();
            _movement.LookAtTarget();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _movement.StopCoroutine(_coroutine);
        }

        private Vector2 GetRandomVector()
        {
            var dir = (gameObject.transform.position - gameObject.transform.parent.position).normalized;
            var angle = Random.Range(-90f, 90f);
            return Utils.RotateVector(dir, angle) * roamDistance + (Vector2) gameObject.transform.position;
        }

        private IEnumerator GetRandomTarget(float delay)
        {
            while (true)
            {
                _movement.target = GetRandomVector();
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
