using System;
using UnityEngine;

namespace Managers
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager instance;
    
        public float startTime;
        public int dayDuration;
        
        private float _time;

        public static Action onDayStart;
    
        private void Awake()
        {
            if (instance != null && instance != this) throw new Exception("Multiple Singleton");
            instance = this;
        }

        private void Start() => _time = startTime;

        private void Update()
        {
            _time += UnityEngine.Time.deltaTime;
            if (_time < dayDuration) return;
            onDayStart?.Invoke();
            _time %= dayDuration;
        }

        public float Time => _time / dayDuration;
    }
}