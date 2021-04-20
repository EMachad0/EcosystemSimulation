using System.Linq;
using Abstract;
using UnityEngine;

namespace Model.Creature.CreatureFSM
{
    public class GoToFoodState : BaseFsm
    {
        private CreatureMovement _movement;
        private CreatureFieldOfView _fov;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            _movement = gameObject.GetComponent<CreatureMovement>();
            _fov = gameObject.GetComponent<CreatureFieldOfView>();
            
            _movement.isRunning = false;
            _movement.target = GetFoodPos();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            if (!_movement.IsMoving()) _movement.target = GetFoodPos();

            _movement.LookAtTarget();
            _movement.Move();
        }

        private Vector2 GetFoodPos()
        {
            foreach (var t in _fov.visibleTarget.Where(t => t.gameObject.layer == LayerMask.NameToLayer("Food")))
            {
                return t.transform.position;
            }
            return gameObject.transform.position;
        }
    }
}