using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustableUpgradeCosts.Framework
{
    class ModConfig
    {

        public BlueprintCost Coop { get; set; } = new BlueprintCost();
        public BlueprintCost BigCoop { get; set; } = new BlueprintCost();
        public BlueprintCost DeluxeCoop { get; set; } = new BlueprintCost();
        public BlueprintCost Barn { get; set; } = new BlueprintCost();
        public BlueprintCost BigBarn { get; set; } = new BlueprintCost();
        public BlueprintCost DeluxeBarn { get; set; } = new BlueprintCost();
        public BlueprintCost Shed { get; set; } = new BlueprintCost();
        public BlueprintCost BigShed { get; set; } = new BlueprintCost();
        public BlueprintCost Silo { get; set; } = new BlueprintCost();
        public BlueprintCost Mill { get; set; } = new BlueprintCost();
        public BlueprintCost Well { get; set; } = new BlueprintCost();
        public BlueprintCost Stable { get; set; } = new BlueprintCost();
        public BlueprintCost FishPond { get; set; } = new BlueprintCost();
        public BlueprintCost SlimeHutch { get; set; } = new BlueprintCost();
        public BlueprintCost ShippingBin { get; set; } = new BlueprintCost();

        public ModConfig()
        {
            this.Coop.GoldCost = 4000;
            this.Coop.Items.Add(new ItemAmount((int) ItemID.WOOD, 300));
            this.Coop.Items.Add(new ItemAmount((int) ItemID.STONE, 100));

            this.BigCoop.GoldCost = 10000;
            this.BigCoop.Items.Add(new ItemAmount((int) ItemID.WOOD, 400));
            this.BigCoop.Items.Add(new ItemAmount((int) ItemID.STONE, 150));

            this.DeluxeCoop.GoldCost = 20000;
            this.DeluxeCoop.Items.Add(new ItemAmount((int) ItemID.WOOD, 500));
            this.DeluxeCoop.Items.Add(new ItemAmount((int) ItemID.STONE, 200));

            this.Barn.GoldCost = 6000;
            this.Barn.Items.Add(new ItemAmount((int) ItemID.WOOD, 350));
            this.Barn.Items.Add(new ItemAmount((int) ItemID.STONE, 150));

            this.BigBarn.GoldCost = 12000;
            this.BigBarn.Items.Add(new ItemAmount((int) ItemID.WOOD, 450));
            this.BigBarn.Items.Add(new ItemAmount((int) ItemID.STONE, 200));

            this.DeluxeBarn.GoldCost = 25000;
            this.DeluxeBarn.Items.Add(new ItemAmount((int) ItemID.WOOD, 550));
            this.DeluxeBarn.Items.Add(new ItemAmount((int) ItemID.STONE, 300));


            this.Silo.GoldCost = 10000;
            this.Silo.Items.Add(new ItemAmount((int) ItemID.STONE, 500));
            this.Silo.Items.Add(new ItemAmount((int) ItemID.CLAY, 25));
            this.Silo.Items.Add(new ItemAmount((int) ItemID.COPPER_BAR, 500));

            this.Mill.GoldCost = 10000;
            this.Mill.Items.Add(new ItemAmount((int) ItemID.STONE, 500));
            this.Mill.Items.Add(new ItemAmount((int) ItemID.CLAY, 25));
            this.Mill.Items.Add(new ItemAmount((int) ItemID.COPPER_BAR, 500));
        }
    }
}
