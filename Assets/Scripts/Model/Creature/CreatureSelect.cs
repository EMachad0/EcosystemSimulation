using System;
using Abstract;
using UnityEngine;

namespace Model.Creature
{
    public class CreatureSelect : Selectable
    {
        public static Action<GameObject> onCreatureSelect;
        public static Action<GameObject> onCreatureUnSelect;

        protected override void Select() => onCreatureSelect?.Invoke(gameObject);

        protected override void UnSelect() => onCreatureUnSelect?.Invoke(gameObject);
    }
}