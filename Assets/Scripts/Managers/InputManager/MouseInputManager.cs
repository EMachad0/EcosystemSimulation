using System;
using System.Collections.Generic;
using Abstract;
using UnityEngine;

namespace Managers.InputManager
{
    public class MouseInputManager : InputManager
    {
        public bool moveOnBorder;
        [Range(0, 1)] public float borderInputPercentage;
        public LayerMask selectablesMask;
        public Camera mainCamera;
        [HideInInspector] public List<Selectable> selectedObjects;

        public static event MoveInputHandler OnMoveInput;
        public static event ZoomInputHandler OnZoomInput;
        public static Action<Vector3> onDragStart;
        public static Action<Vector3> onDragInput;

        private float _offsetX;
        private float _offsetY;
        private Vector2 _screen;

        private void Awake()
        {
            _screen = new Vector2(Screen.width, Screen.height);
            _offsetX = _screen.x * borderInputPercentage / 2;
            _offsetY = _screen.y * borderInputPercentage / 2;
        }
    
        private void Update()
        {
            var pos = Input.mousePosition;
            var insideScreen = -_offsetX <= pos.x && pos.x <= _screen.x + _offsetX && -_offsetY <= pos.y && pos.y <= _screen.y + _offsetY;
            if (!insideScreen) return;
            
            if (moveOnBorder)
            {
                if (pos.x <= _offsetX) OnMoveInput?.Invoke(Vector3.left);
                if (pos.x >= _screen.x - _offsetX) OnMoveInput?.Invoke(Vector3.right);
                if (pos.y <= _offsetY) OnMoveInput?.Invoke(Vector3.down);
                if (pos.y >= _screen.y - _offsetY) OnMoveInput?.Invoke(Vector3.up);
            }

            if (Input.GetMouseButtonDown(0)) SelectionCheck();
                
            if (Input.mouseScrollDelta.y != 0) OnZoomInput?.Invoke(-Input.mouseScrollDelta.y);

            if (Input.GetMouseButtonDown(1)) onDragStart?.Invoke(Input.mousePosition);
            if (Input.GetMouseButton(1)) onDragInput?.Invoke(Input.mousePosition);
        }

        private void SelectionCheck()
        {
            foreach (var selectable in selectedObjects) selectable.SelectEnd();
            selectedObjects.Clear();
            var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Input.mousePosition), Mathf.Infinity, selectablesMask);
            if (rayHit.transform is null) return;
            var selectableHit = rayHit.transform.GetComponent<Selectable>();
            selectableHit.SelectStart();
            selectedObjects.Add(selectableHit);
        }
    }
}