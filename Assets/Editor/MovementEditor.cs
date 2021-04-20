using Model.Creature;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(CreatureMovement))]
    public class MovementEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            var movement = (CreatureMovement) target;
            Handles.color = Color.yellow;
            Handles.DrawWireArc(movement.target, Vector3.forward, Vector3.up, 360, .2f);
            Handles.DrawLine(movement.transform.position, movement.target);
        }
    }
}