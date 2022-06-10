using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustableBuildingCosts.Framework
{
    class ItemAmount
    {
        public int ItemID { get; set; } = 300;
        public int Amount { get; set; } = 1000;

        public ItemAmount(int ItemID, int Amount)
        {
            this.ItemID = ItemID;
            this.Amount = Amount;
        }
    }
}
