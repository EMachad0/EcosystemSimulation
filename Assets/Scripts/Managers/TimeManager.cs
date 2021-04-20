using System;
using UnityEngine;

namespace Managers
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager instance;
    
        public int maxTime;
        public float time;
        public float relativeTime;

        public static Action onDayStart;
    
        private void Awake()
        {
            if (instance != null && instance != this) throw new Exception("Multiple Singleton");
            instance = this;
        }

        private void Update()
        {
            time += Time.deltaTime;
            relativeTime = time / maxTime;
            if (time < maxTime) return;
            onDayStart?.Invoke();
            time %= maxTime;
        }
    }
}