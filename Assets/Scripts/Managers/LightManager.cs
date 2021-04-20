using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Managers
{
    [ExecuteAlways]
    public class LightManager : MonoBehaviour
    {
        [Range(0, 1)] public float time;
        public Light2D light2d;
        public Gradient ambientColor;

        private void Update()
        {
            if (!Application.isPlaying) UpdateLighting(time);
            else UpdateLighting(TimeManager.instance.time / TimeManager.instance.maxTime);
        }
    
        private void UpdateLighting(float timePercent)
        {
            light2d.color = ambientColor.Evaluate(timePercent);
            light2d.intensity = ambientColor.Evaluate(timePercent).a;
        }
    }
}