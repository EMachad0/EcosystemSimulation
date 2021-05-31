using System.Collections;
using Managers;
using Model.Creature;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Model.Village
{
    public class VillageController : MonoBehaviour
    {
        [Header("Awake")]
        public int startPopulation;

        [Header("Daily Spawns")]
        public float spawnRange;
        public int spawnPerFrame;
        public LayerMask spawnColliders;

        private VillageStats _stats;
        private VillageNaturalSelection _naturalSelection;
        
        private void Awake()
        {
            _stats = GetComponent<VillageStats>();
            _naturalSelection = GetComponent<VillageNaturalSelection>();
            
            StartPopulation();
            TimeManager.onDayStart += OnDayStart;
        }

        private void StartPopulation()
        {
            for (var i = 0; i < startPopulation; i++)
            {
                var obj = CreatureSpawnManager.instance.MakeCreature(transform);
                obj.GetComponent<CreatureVillageSystem>().EnterVillage(gameObject);
            }
        }

        private void OnDayStart()
        {
            _stats.NewEntries();
            if (transform.childCount == 0) return;
            _naturalSelection.Reproduce();
            StartCoroutine(SpawnCreatures());
        }

        private IEnumerator SpawnCreatures()
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                var o = transform.GetChild(i).gameObject;
                if (o.activeSelf) continue;
                SpawnCreature(o);
                if (i != 0 && i % spawnPerFrame == 0) yield return null;
            }
        }

        private void SpawnCreature(GameObject obj)
        {
            var pos = (Vector3) Random.insideUnitCircle * spawnRange;
            obj.GetComponent<CreatureVillageSystem>().ExitVillage(pos);
        }
    }
}