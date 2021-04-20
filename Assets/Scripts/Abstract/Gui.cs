using UnityEngine;

namespace Abstract
{
    public abstract class Gui : MonoBehaviour
    {
        private CanvasGroup _group;
            
        private void Awake() => _group = GetComponent<CanvasGroup>();

        private void Start() => _group.alpha = 0;
        
        private void Update()
        {
            if (!IsEnabled) return;
            EnabledUpdate();
        }

        protected virtual void EnabledUpdate() {}

        protected void Show() => _group.alpha = 1;
        
        protected void Hide() => _group.alpha = 0;
        public bool IsEnabled => _group.alpha > 0;
    }
}