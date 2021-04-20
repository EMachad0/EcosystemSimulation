using Managers;
using Model.Village;
using UnityEngine;

namespace Village
{
    [ExecuteAlways]
    public class VillageSize : MonoBehaviour
    {
        private VillageController _controller;

        [SerializeField] private float scaleFactor;

        private static float ScaleFunc(float x) => 1 + Mathf.Log(x);

        private void Awake()
        {
            _controller = GetComponent<VillageController>();

            TimeManager.onDayStart += UpdateSize;
        }

        private void Update()
        {
            if (!Application.isPlaying && ScaleFactor > 0) UpdateSize();
        }

        private void UpdateSize()
        {
            // if (Application.isPlaying) ScaleFactor = _controller.Reproducibles.Count + _controller.NonReproducibles.Count;
            gameObject.transform.localScale = new Vector3(ScaleFactor, ScaleFactor, 1);
        }

        public float ScaleFactor
        {
            get => ScaleFunc(scaleFactor);
            private set => scaleFactor = value;
        }
    }
}