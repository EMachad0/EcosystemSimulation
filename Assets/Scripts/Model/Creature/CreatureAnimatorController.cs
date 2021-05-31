using Managers;
using UnityEngine;

namespace Model.Creature
{
    public class CreatureAnimatorController : MonoBehaviour
    {
        private Animator _animator;
        private CreatureFoodSystem _foodSystem;
        private CreatureMovement _movement;
        
        private static readonly int DayTime = Animator.StringToHash("DayTime");
        private static readonly int FoodTaken = Animator.StringToHash("FoodTaken");
        private static readonly int SeeingFood = Animator.StringToHash("SeeingFood");
        private static readonly int Moving = Animator.StringToHash("Moving");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _foodSystem = GetComponent<CreatureFoodSystem>();
            _movement = GetComponent<CreatureMovement>();
        }

        private void Update()
        {
            _animator.SetFloat(DayTime, TimeManager.instance.Time);
            _animator.SetInteger(FoodTaken, _foodSystem.FoodTaken);
            _animator.SetBool(SeeingFood, _foodSystem.IsSeeingFood());
            _animator.SetBool(Moving, _movement.IsMoving());
        }
    }
}