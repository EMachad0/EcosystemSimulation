using System;
using UnityEngine;

namespace Model.Village
{
    public class VillageSelect : Abstract.Selectable
    {
        public static Action<GameObject> onVillageSelect;
        public static Action<GameObject> onVillageUnSelect;
        
        protected override void Select() => onVillageSelect?.Invoke(gameObject);

        protected override void UnSelect() => onVillageUnSelect?.Invoke(gameObject);
    }
}