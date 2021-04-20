using UnityEngine;

namespace Abstract
{
    public abstract class BaseFsm : StateMachineBehaviour
    {
        protected GameObject gameObject;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            gameObject = animator.gameObject;
        }
    }
}