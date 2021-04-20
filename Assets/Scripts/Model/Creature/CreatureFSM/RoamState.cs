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

        private void GetRandomTarget()
        {
            _movement.target = Random.onUnitSphere.normalized * roamDistance + gameObject.transform.position;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _movement.StopCoroutine(_coroutine);
        }

        private IEnumerator GetRandomTarget(float delay)
        {
            while (true)
            {
                _movement.target = Random.onUnitSphere.normalized * roamDistance + gameObject.transform.position;
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
