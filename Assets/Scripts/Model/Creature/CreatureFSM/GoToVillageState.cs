using Abstract;
using UnityEngine;

namespace Model.Creature.CreatureFSM
{
    public class GoToVillageState : BaseFsm
    {
        private CreatureMovement _movement;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            _movement = gameObject.GetComponent<CreatureMovement>();

            _movement.isRunning = true;
            _movement.target = gameObject.transform.parent.position;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            _movement.LookAtTarget();
            _movement.Move();
        }
    }
}
