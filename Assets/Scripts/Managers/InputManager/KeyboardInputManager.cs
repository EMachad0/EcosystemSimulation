using UnityEngine;

namespace Managers.InputManager
{
    public class KeyboardInputManager : InputManager
    {
        public static event MoveInputHandler OnMoveInput;
    
        private void Update()
        {
            if (Input.GetKey(KeyCode.W)) OnMoveInput?.Invoke(Vector3.up);
            if (Input.GetKey(KeyCode.A)) OnMoveInput?.Invoke(Vector3.left);
            if (Input.GetKey(KeyCode.S)) OnMoveInput?.Invoke(Vector3.down);
            if (Input.GetKey(KeyCode.D)) OnMoveInput?.Invoke(Vector3.right);
        }
    }
}