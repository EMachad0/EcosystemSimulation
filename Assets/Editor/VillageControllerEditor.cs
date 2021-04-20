using Model.Village;
using UnityEditor;
using UnityEngine;
using Village;

namespace Editor
{
    [CustomEditor(typeof(VillageController))]
    public class VillageControllerEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            var controller = (VillageController) target;
            Handles.color = Color.yellow;
            Handles.DrawWireArc(controller.transform.position, Vector3.forward, Vector3.up, 360, controller.spawnRange);
        }
    }
}
