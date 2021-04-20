using System.Globalization;
using Abstract;
using Model.Creature;
using Model.Creature.Genetics;
using Model.Creature.Genetics.Genes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class GuiCreature : Gui
    {
        public Image image;
        public TextMeshProUGUI fovAngleValue;
        public TextMeshProUGUI fovRadiusValue;
        public TextMeshProUGUI speedValue;

        private Dna _dna;
        private CreatureFieldOfView _fov;
        private CreatureMovement _movement;

        private void OnEnable()
        {
            CreatureSelect.onCreatureSelect += OnCreatureSelect;
            CreatureSelect.onCreatureUnSelect += OnCreatureUnSelect;
        }

        private void OnDisable()
        {
            CreatureSelect.onCreatureSelect -= OnCreatureSelect;
            CreatureSelect.onCreatureUnSelect -= OnCreatureUnSelect;
        }

        protected override void EnabledUpdate()
        {
            image.color = ((ColorGene) _dna.genes[0]).color;
            speedValue.text = _movement.walkSpeed.ToString("F", CultureInfo.InvariantCulture);
            fovAngleValue.text = _fov.fovAngle.ToString("F", CultureInfo.InvariantCulture);
            fovRadiusValue.text = _fov.fovRadius.ToString("F", CultureInfo.InvariantCulture);
        }

        private void OnCreatureSelect(GameObject o)
        {
            Show();
            
            _dna = o.GetComponent<Dna>();
            _fov = o.GetComponent<CreatureFieldOfView>();
            _movement = o.GetComponent<CreatureMovement>();
        }

        private void OnCreatureUnSelect(GameObject o)
        {
            Hide();
        }
    }
}