using System.Collections.Generic;
using UnityEngine;

namespace Model.Creature.Genetics
{
    [ExecuteAlways]
    public class Dna : MonoBehaviour
    {
        [Header("NaturalSelection")]
        [Range(0, 1)] public float birthRate;
        [Range(0, 1)] public float mutationRate;
        
        [Header("Genes")]
        public List<Gene> genes;

        private void Start()
        {
            ApplyGenes();
        }

        private void Update()
        {
            if (!Application.isPlaying) ApplyGenes();
        }

        private void ApplyGenes()
        {
            foreach (var gene in genes) gene.ApplyGene(gameObject);
        }

        public void Heredity(Dna d1, Dna d2)
        {
            for (var i = 0; i < d1.genes.Count; i++)
            {
                var g = (Gene) ScriptableObject.CreateInstance(d1.genes[i].GetType());
                g.Heredity(d1.genes[i], d2.genes[i]);
                if (Random.value < mutationRate) g.Mutate();
                genes.Add(g);
            }
            ApplyGenes();
        }
    }
}