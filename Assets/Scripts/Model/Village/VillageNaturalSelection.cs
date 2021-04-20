using Managers;
using Model.Creature;
using Model.Creature.Genetics;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Model.Village
{
    public class VillageNaturalSelection : MonoBehaviour
    {
        private VillageStats _stats;

        private void Awake()
        {
            _stats = GetComponent<VillageStats>();
        }

        public void Reproduce()
        {
            var childCount = transform.childCount;
            var foods = new int[childCount];
            var poll = new int[childCount];

            for (var i = 0; i < childCount; i++)
            {
                var foodSystem = transform.GetChild(i).GetComponent<CreatureFoodSystem>();
                foods[i] = foodSystem.FoodTaken;
                poll[i] = FitFunction(foods[i]);
            }
            for (var i = 1; i < poll.Length; i++) poll[i] += poll[i - 1];
            var maxPoll = poll[poll.Length - 1];

            for (var i1 = childCount - 1; i1 >= 0; i1--)
            {
                var dna = transform.GetChild(i1).GetComponent<Dna>();
                var p1 = transform.GetChild(i1).gameObject;
                for (var f = 1; f < foods[i1]; f++)
                {
                    if (Random.value > dna.birthRate) continue;
                    var i2 = Utils.BinarySearch(poll, Random.Range(0, maxPoll));
                    if (i1 == i2) continue;
                    var p2 = transform.GetChild(i2).gameObject;
                    
                    var son = CreatureSpawnManager.instance.Reproduce(p1, p2);
                    son.transform.SetParent(transform);
                }
            }
        }
        
        private static int FitFunction(int x) => (int) math.pow(x, 4);
    }
}