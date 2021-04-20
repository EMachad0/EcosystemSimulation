using System;
using UnityEngine;

namespace Unused.Managers
{
    public class NaturalSelectionManager : MonoBehaviour
    {
        public static NaturalSelectionManager instance;

        public float mutationRate;
    
        private void Awake()
        {
            if (instance != null && instance != this) throw new Exception("Multiple Singleton");
            instance = this;
        }
    }
}