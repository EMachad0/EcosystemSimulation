using UnityEngine;

namespace Model.Creature.Genetics
{
    public abstract class Gene : ScriptableObject
    {
        protected virtual void ApplyGenotype(GameObject g) {}
        protected virtual void ApplyPhenotype(GameObject g) {}

        public void ApplyGene(GameObject g)
        {
            ApplyGenotype(g);
            ApplyPhenotype(g);
        }

        public abstract void Heredity(Gene g1, Gene g2);

        public abstract void Mutate();
    }
}