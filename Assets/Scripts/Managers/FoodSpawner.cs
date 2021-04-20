using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class FoodSpawner : MonoBehaviour
    {
        public static FoodSpawner instance;
    
        public int quantityToSpawn;
        public int spawnOnStart;

        public GameObject world;
        public GameObject prefab;
        public LayerMask colliders;
    
        private Rect _rect;

        private void Awake()
        {
            if (instance != null && instance != this) throw new Exception("Multiple Singleton");
            instance = this;
        
            TimeManager.onDayStart += OnDayStart;
            _rect = ((RectTransform) world.transform).rect;
        }

        private void Start()
        {
            SpawnFood(spawnOnStart);
        }

        private void OnDayStart()
        {
            for (var i = transform.childCount - 1; i >= 0; i--) Destroy(transform.GetChild(i).gameObject);
            SpawnFood(quantityToSpawn);
        }

        private void SpawnFood(int quantity)
        {
            for (var i = 0; i < quantity; i++) StartCoroutine(SpawnFood());
        }

        private IEnumerator SpawnFood()
        {
            var range = _rect.width / 2;
            Vector3 pos;
            do
            {
                pos = new Vector3(Random.Range(-range, range), Random.Range(-range, range), 0) + transform.position;
                var overlap = Physics2D.OverlapBox(pos, prefab.transform.localScale, 0, colliders);
                if (overlap is null) break;
                yield return null;
            } while (true);
            Instantiate(prefab, pos, Quaternion.Euler(Vector3.zero), transform);
        }
    }
}