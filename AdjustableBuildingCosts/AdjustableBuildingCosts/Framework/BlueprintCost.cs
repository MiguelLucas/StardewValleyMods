using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustableUpgradeCosts.Framework
{
    internal class BlueprintCost
    {
        /// <summary>The color to use for the <see cref="Farmer.fishingSkill"/> skill.</summary>
        public int GoldCost { get; set; } = 1000;

        public List<ItemAmount> Items { get; set; } = new List<ItemAmount>();
    }
}
