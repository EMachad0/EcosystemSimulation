using System;
using Model.Creature;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(CreatureFieldOfView))]
    public class FieldOfViewEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            var fov = (CreatureFieldOfView) target;
            var position = fov.transform.position;
            
            Handles.color = Color.black;
            Handles.DrawWireArc(position, Vector3.forward, Vector3.up, 360, fov.fovRadius);

            if (Math.Abs(fov.fovAngle - 360) > 0.001f)
            {
                var angL = fov.DirFromAngle(-fov.fovAngle / 2);
                var angR = fov.DirFromAngle(fov.fovAngle / 2);
                Handles.DrawLine(position, position + angL * fov.fovRadius);
                Handles.DrawLine(position, position + angR * fov.fovRadius);
            }
            

            foreach (var t in fov.visibleTarget)
            {
                Handles.color = Color.red;
                Handles.DrawLine(fov.transform.position, t.position);
            }
        }
    }
}