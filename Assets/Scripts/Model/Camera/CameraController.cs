using Managers.InputManager;
using UnityEngine;

namespace Model.Camera
{
    public class CameraController : MonoBehaviour
    {
        [Header("Camera Positioning")]
        public Vector3 cameraOffset;

        [Header("Move Speed")]
        public Vector2 moveSpeed;
        public float zoomSpeed;

        [Header("Bounds")]
        public Vector2 minBounds = new Vector3(int.MinValue, int.MinValue);
        public Vector2 maxBounds = new Vector3(int.MaxValue, int.MaxValue);
        public float mimZoom;
        public float maxZoom;

        private UnityEngine.Camera _cam;
        private Vector2 _frameMove;
        private float _frameZoom;
        private Vector3 _dragStart, _mouseDragStart;

        private void Awake()
        {
            _cam = GetComponentInChildren<UnityEngine.Camera>();
            _cam.transform.localPosition = cameraOffset;
            _cam.transform.LookAt(transform);
        }

        private void OnEnable()
        {
            KeyboardInputManager.OnMoveInput += UpdateFrameMovement;
            MouseInputManager.OnMoveInput += UpdateFrameMovement;
            MouseInputManager.OnZoomInput += UpdateFrameZoom;
            MouseInputManager.onDragStart += DragStart;
            MouseInputManager.onDragInput += UpdateDrag;
        }

        private void OnDisable()
        {
            KeyboardInputManager.OnMoveInput -= UpdateFrameMovement;
            MouseInputManager.OnMoveInput -= UpdateFrameMovement;
            MouseInputManager.OnZoomInput -= UpdateFrameZoom;
            MouseInputManager.onDragStart -= DragStart;
            MouseInputManager.onDragInput -= UpdateDrag;
        }

        private void UpdateFrameMovement(Vector3 moveVector) => _frameMove += (Vector2) moveVector;
        private void UpdateFrameZoom(float zoomValue) => _frameZoom += zoomValue;

        private void LateUpdate()
        {
            if (_frameMove != Vector2.zero)
            {
                var move = new Vector2(_frameMove.x * moveSpeed.x, _frameMove.y * moveSpeed.y);
                transform.position += transform.TransformDirection(move) * Time.deltaTime;
                LockMoveInBounds();
                _frameMove = Vector2.zero;
            }

            if (_frameZoom != 0)
            {
                var delta = _cam.orthographicSize + _frameZoom * zoomSpeed * Time.deltaTime;
                _cam.orthographicSize = Mathf.Clamp(delta, mimZoom, maxZoom);
                _frameZoom = 0;
            }
        }

        private void LockMoveInBounds()
        {
            var pos = transform.position;
            var x = Mathf.Clamp(pos.x, minBounds.x, maxBounds.x);
            var y = Mathf.Clamp(pos.y, minBounds.y, maxBounds.y);
            transform.position = new Vector3(x, y, 0);
        }
    
        private void DragStart(Vector3 mousePos)
        {
            _dragStart = transform.position;
            _mouseDragStart = mousePos;
        }

        private void UpdateDrag(Vector3 mousePos)
        {
            var dragVector = _cam.ScreenToWorldPoint(_mouseDragStart) - _cam.ScreenToWorldPoint(mousePos);
            transform.position = _dragStart + dragVector;
        }
    }
}
