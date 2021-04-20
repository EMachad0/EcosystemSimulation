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
            _naturalSelection.Reproduce();

            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                var o = transform.GetChild(i).gameObject;
                StartCoroutine(SpawnCreature(o));
            }
        }

        private IEnumerator SpawnCreature(GameObject obj)
        {
            var range = spawnRange / 2;
            Vector3 pos;
            do
            {
                pos = new Vector3(Random.Range(-range, range), Random.Range(-range, range), 0) + transform.position;
                var overlap = Physics2D.OverlapBox(pos, obj.transform.localScale, 0, spawnColliders);
                if (overlap is null) break;
                yield return null;
            } while (true);
            obj.GetComponent<CreatureVillageSystem>().ExitVillage(pos);
        }
    }
}