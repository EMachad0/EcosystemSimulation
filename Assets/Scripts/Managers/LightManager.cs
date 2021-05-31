using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Managers
{
    [ExecuteAlways]
    public class LightManager : MonoBehaviour
    {
        [Header("Editor")]
        [Range(0, 1)] public float editorTime;

        public Light2D light2d;
        public Gradient ambientColor;

        private void Update()
        {
            UpdateLighting(!Application.isPlaying ? editorTime : TimeManager.instance.Time);
        }
    
        private void UpdateLighting(float timePercent)
        {
            light2d.color = ambientColor.Evaluate(timePercent);
            light2d.intensity = ambientColor.Evaluate(timePercent).a;
        }
    }
}