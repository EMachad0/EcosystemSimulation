using Abstract;
using Model.Village;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class GuiVillage : Gui
    {
        private VillageStats _stats;

        public Image avgColor;
        public TextMeshProUGUI textPopYesterday;
        public TextMeshProUGUI textFoodYesterday;
        public TextMeshProUGUI textPopToday;
        public TextMeshProUGUI textFoodToday;

        private void OnEnable()
        {
            VillageSelect.onVillageSelect += OnVillageSelect;
            VillageSelect.onVillageUnSelect += OnVillageUnSelect;
        }

        private void OnDisable()
        {
            VillageSelect.onVillageSelect -= OnVillageSelect;
            VillageSelect.onVillageUnSelect -= OnVillageUnSelect;
        }

        protected override void EnabledUpdate()
        {
            avgColor.color = _stats.avgColor;
            if (_stats.foodDaily.Count >= 1) textFoodToday.text = _stats.foodDaily[_stats.foodDaily.Count - 1].ToString();
            if (_stats.popDaily.Count >= 1) textPopToday.text = _stats.popDaily[_stats.popDaily.Count - 1].ToString();
            if (_stats.foodDaily.Count >= 2) textFoodYesterday.text = _stats.foodDaily[_stats.foodDaily.Count - 2].ToString();
            if (_stats.popDaily.Count >= 2) textPopYesterday.text = _stats.popDaily[_stats.popDaily.Count - 2].ToString();
        }

        private void OnVillageSelect(GameObject o)
        {
            Show();
            _stats = o.GetComponent<VillageStats>();
        }

        private void OnVillageUnSelect(GameObject o)
        {
            Hide();
        }
    }
}