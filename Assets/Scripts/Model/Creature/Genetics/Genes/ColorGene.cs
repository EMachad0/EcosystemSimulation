using UnityEngine;

namespace Model.Creature.Genetics.Genes
{
    [CreateAssetMenu(fileName = "ColorGene", menuName = "ScriptableObjects/Genes/ColorGene", order = 1)]
    public class ColorGene : Gene
    {
        public Color color;
        public float mutationForce;

        protected override void ApplyGenotype(GameObject g)
        {
            var movement = g.GetComponent<CreatureMovement>();
            var fov = g.GetComponent<CreatureFieldOfView>();

            fov.fovAngle = 20 + 340 * color.r;
            fov.fovRadius = 2 + 8 * color.g;
            movement.walkSpeed = 2 + 2 * color.b;
        }

        protected override void ApplyPhenotype(GameObject g)
        {
            g.GetComponent<SpriteRenderer>().color = color;
        }

        public override void Heredity(Gene g1, Gene g2)
        {
            color = Color.Lerp(((ColorGene) g1).color, ((ColorGene) g2).color, .5f);
        }

        public override void Mutate()
        {
            color.r += Random.Range(-mutationForce, mutationForce);
            color.g += Random.Range(-mutationForce, mutationForce);
            color.b += Random.Range(-mutationForce, mutationForce);
        }
    }
}