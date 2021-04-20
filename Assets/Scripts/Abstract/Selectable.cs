using UnityEngine;

namespace Abstract
{
    public abstract class Selectable : MonoBehaviour
    {
        public bool isSelected;

        public void SelectStart()
        {
            isSelected = true;
            Select();
        }
    
        public void SelectEnd()
        {
            isSelected = false;
            UnSelect();
        }
    
        protected abstract void Select();
        protected abstract void UnSelect();

        private void Update()
        {
            if (isSelected) SelectedUpdate();
        }

        protected virtual void SelectedUpdate() {}
    }
}