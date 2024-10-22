using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustableBuildingCosts.Framework
{
    class BuildItem
    {
        public int ItemId { get; set; } = (int)ItemID.WOOD;
        public int Amount { get; set; } = 1000;

        public BuildItem(int ItemID, int Amount)
        {
            this.ItemId = ItemID;
            this.Amount = Amount;
        }
    }
}
