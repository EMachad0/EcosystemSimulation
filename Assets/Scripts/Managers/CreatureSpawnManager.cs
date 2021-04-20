using System;
using Model.Creature.Genetics;
using UnityEngine;

namespace Managers
{
    public class CreatureSpawnManager : MonoBehaviour
    {
        public static CreatureSpawnManager instance;
    
        public GameObject creaturePrefab;
    
        private void Awake()
        {
            if (instance != null && instance != this) throw new Exception("Multiple Singleton");
            instance = this;
        }
    
        public GameObject MakeCreature()
        {
            return Instantiate(creaturePrefab);
        }
    
        public GameObject MakeCreature(Transform parent)
        {
            return Instantiate(creaturePrefab, parent);
        }

        public GameObject Reproduce(GameObject p1, GameObject p2)
        {
            var obj = Instantiate(creaturePrefab);
            var dnaSon = obj.GetComponent<Dna>();
            var dnaP1 = p1.GetComponent<Dna>();
            var dnaP2 = p2.GetComponent<Dna>();
            dnaSon.Heredity(dnaP1, dnaP2);
            return obj;
        }
    }
}