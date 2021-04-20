using Abstract;
using UnityEngine;

namespace Model.Creature.CreatureFSM
{
    public class GoAwayFromVillageState : BaseFsm
    {
        private CreatureMovement _movement;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            _movement = gameObject.GetComponent<CreatureMovement>();
            
            var dir = (gameObject.transform.position - gameObject.transform.parent.position).normalized;
            _movement.target = dir * 100;
            _movement.isRunning = true;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            _movement.LookAtTarget();
            _movement.Move();
        }
    }
}
