using Abstract;
using UnityEngine;

namespace Model.Creature.CreatureFSM
{
    public class DieState : BaseFsm
    {
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            Destroy(gameObject);
        }
    }
}
