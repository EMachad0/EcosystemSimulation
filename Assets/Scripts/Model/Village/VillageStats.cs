using System.Collections.Generic;
using Model.Creature;
using UnityEngine;

namespace Model.Village
{
    public class VillageStats : MonoBehaviour
    {

        public Color avgColor;
        public readonly List<int> foodDaily = new List<int>();
        public readonly List<int> popDaily = new List<int>();

        internal void NewEntries()
        {
            avgColor = CalcAvgColor();
            foodDaily.Add(CalcTotalFood());
            popDaily.Add(CalcTotalPop());
        }

        private int CalcTotalPop() => transform.childCount;

        private int CalcTotalFood()
        {
            var sum = 0;
            for (var i = 0; i < transform.childCount; i++)
            {
                var foodSystem = transform.GetChild(i).GetComponent<CreatureFoodSystem>();
                sum += foodSystem.FoodTaken;
            }
            return sum;
        }

        private Color CalcAvgColor()
        {
            var childCount = transform.childCount;
            float r = 0, g = 0, b = 0;
            for (var i = 0; i < childCount; i++)
            {
                var color = transform.GetChild(i).GetComponent<SpriteRenderer>().color;
                r += color.r;
                g += color.g;
                b += color.b;
            }
            return new Color(r / childCount, g / childCount, b / childCount);
        }

        public int FoodToday() => foodDaily[foodDaily.Count - 1];
        public int PopToday() => popDaily[popDaily.Count - 1];
    }
}