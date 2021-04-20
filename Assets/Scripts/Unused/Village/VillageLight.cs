using System;
using Managers;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Village
{
    [ExecuteAlways]
    public class VillageLight : MonoBehaviour
    {
        public float startRadius;
        
        private Light2D _light;
        private VillageSize _villageSize;
        
        private void Awake()
        {
            _light = GetComponent<Light2D>();
            _villageSize = GetComponent<VillageSize>();

            TimeManager.onDayStart += UpdateLight;
        }

        private void Update()
        {
            if (!Application.isPlaying) UpdateLight();
        }

        private void UpdateLight()
        {
            _light.pointLightOuterRadius = startRadius * _villageSize.ScaleFactor;
        }
    }
}