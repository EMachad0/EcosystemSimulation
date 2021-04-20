using UnityEngine;

namespace Managers.InputManager
{
    public abstract class InputManager : MonoBehaviour
    {
        public delegate void MoveInputHandler(Vector3 moveVector);
        public delegate void ZoomInputHandler(float zoomValue);
    }
}