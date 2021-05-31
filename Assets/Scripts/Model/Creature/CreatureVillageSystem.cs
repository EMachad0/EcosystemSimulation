using UnityEngine;

namespace Model.Creature
{
    public class CreatureVillageSystem : MonoBehaviour
    {
        private CreatureFoodSystem _foodSystem;

        private void Awake()
        {
            _foodSystem = GetComponent<CreatureFoodSystem>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var obj = other.gameObject;
            if (obj.layer != LayerMask.NameToLayer("Village")) return;
            transform.SetParent(obj.transform);
            if (_foodSystem.FoodTaken == 0) return;
            EnterVillage(obj);
        }

        public void EnterVillage(GameObject village)
        {
            gameObject.SetActive(false);
            gameObject.transform.SetParent(village.transform);
            transform.position = village.transform.position;
        }

        public void ExitVillage(Vector3 pos)
        {
            transform.position = pos;
            gameObject.SetActive(true);
            _foodSystem.FoodTaken = 0;
        }
    }
}