using System.Linq;
using TMPro;
using UnityEngine;

namespace Model.Creature
{
    public class CreatureFoodSystem : MonoBehaviour
    {
        public TextMeshProUGUI foodGui;
        private CreatureFieldOfView _fov;

        [SerializeField] private int foodTaken;

        private void Awake()
        {
            _fov = GetComponent<CreatureFieldOfView>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Food")) return;
            FoodTaken++;
            Destroy(other.gameObject);
        }

        public bool IsSeeingFood()
        {
            return _fov.visibleTarget.Any(t => t != null && t.gameObject.layer == LayerMask.NameToLayer("Food"));
        }

        public int FoodTaken
        {
            get => foodTaken;
            set
            {
                foodTaken = value;
                foodGui.text = value.ToString();
            }
        }
    }
}