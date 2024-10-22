using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustableBuildingCosts.Framework
{
    class ModConfig
    {
        public Dictionary<string, BlueprintCost> Buildings { get; set; } = new Dictionary<string, BlueprintCost>();

        public ModConfig()
        {
            BlueprintCost coop = new BlueprintCost();
            coop.GoldCost = 4000;
            coop.BuildItems.Add(new BuildItem((int) ItemID.WOOD, 300));
            coop.BuildItems.Add(new BuildItem((int) ItemID.STONE, 100));

            BlueprintCost bigCoop = new BlueprintCost();
            bigCoop.GoldCost = 10000;
            bigCoop.BuildItems.Add(new BuildItem((int) ItemID.WOOD, 400));
            bigCoop.BuildItems.Add(new BuildItem((int) ItemID.STONE, 150));

            BlueprintCost deluxeCoop = new BlueprintCost();
            deluxeCoop.GoldCost = 20000;
            deluxeCoop.BuildItems.Add(new BuildItem((int) ItemID.WOOD, 500));
            deluxeCoop.BuildItems.Add(new BuildItem((int) ItemID.STONE, 200));

            BlueprintCost barn = new BlueprintCost();
            barn.GoldCost = 6000;
            barn.BuildItems.Add(new BuildItem((int) ItemID.WOOD, 350));
            barn.BuildItems.Add(new BuildItem((int) ItemID.STONE, 150));

            BlueprintCost bigBarn = new BlueprintCost();
            bigBarn.GoldCost = 12000;
            bigBarn.BuildItems.Add(new BuildItem((int) ItemID.WOOD, 450));
            bigBarn.BuildItems.Add(new BuildItem((int) ItemID.STONE, 200));

            BlueprintCost deluxeBarn = new BlueprintCost();
            deluxeBarn.GoldCost = 25000;
            deluxeBarn.BuildItems.Add(new BuildItem((int) ItemID.WOOD, 550));
            deluxeBarn.BuildItems.Add(new BuildItem((int) ItemID.STONE, 300));

            BlueprintCost shed = new BlueprintCost();
            shed.GoldCost = 15000;
            shed.BuildItems.Add(new BuildItem((int) ItemID.WOOD, 300));

            BlueprintCost bigShed = new BlueprintCost();
            bigShed.GoldCost = 20000;
            bigShed.BuildItems.Add(new BuildItem((int) ItemID.WOOD, 550));
            bigShed.BuildItems.Add(new BuildItem((int) ItemID.STONE, 300));

            BlueprintCost silo = new BlueprintCost();
            silo.GoldCost = 1000;
            silo.BuildItems.Add(new BuildItem((int) ItemID.STONE, 100));
            silo.BuildItems.Add(new BuildItem((int) ItemID.CLAY, 10));
            silo.BuildItems.Add(new BuildItem((int) ItemID.COPPER_BAR, 5));

            BlueprintCost mill = new BlueprintCost();
            mill.GoldCost = 2500;
            mill.BuildItems.Add(new BuildItem((int) ItemID.WOOD, 150));
            mill.BuildItems.Add(new BuildItem((int) ItemID.STONE, 50));
            mill.BuildItems.Add(new BuildItem((int) ItemID.CLOTH, 4));

            BlueprintCost well = new BlueprintCost();
            well.GoldCost = 1000;
            well.BuildItems.Add(new BuildItem((int) ItemID.STONE, 75));

            BlueprintCost fishPond = new BlueprintCost();
            fishPond.GoldCost = 5000;
            fishPond.BuildItems.Add(new BuildItem((int) ItemID.STONE, 200));
            fishPond.BuildItems.Add(new BuildItem((int) ItemID.SEAWEED, 5));
            fishPond.BuildItems.Add(new BuildItem((int) ItemID.GREEN_ALGAE, 5));

            BlueprintCost stable = new BlueprintCost();
            stable.GoldCost = 10000;
            stable.BuildItems.Add(new BuildItem((int) ItemID.HARDWOOD, 100));
            stable.BuildItems.Add(new BuildItem((int) ItemID.IRON_BAR, 5));

            BlueprintCost slimeHutch = new BlueprintCost();
            slimeHutch.GoldCost = 10000;
            slimeHutch.BuildItems.Add(new BuildItem((int) ItemID.STONE, 500));
            slimeHutch.BuildItems.Add(new BuildItem((int) ItemID.REFINED_QUARTZ, 10));
            slimeHutch.BuildItems.Add(new BuildItem((int) ItemID.IRIDIUM_BAR, 1));

            BlueprintCost cabin = new BlueprintCost();
            cabin.GoldCost = 100;

            BlueprintCost shippingBin = new BlueprintCost();
            shippingBin.GoldCost = 250;
            shippingBin.BuildItems.Add(new BuildItem((int) ItemID.WOOD, 150));

            BlueprintCost goldClock = new BlueprintCost();
            goldClock.GoldCost = 10000000;

            BlueprintCost junimoHut = new BlueprintCost();
            junimoHut.GoldCost = 20000;
            junimoHut.BuildItems.Add(new BuildItem((int) ItemID.STONE, 200));
            junimoHut.BuildItems.Add(new BuildItem((int) ItemID.FIBER, 100));
            junimoHut.BuildItems.Add(new BuildItem((int) ItemID.STARFRUIT, 9));

            BlueprintCost desertObelisk = new BlueprintCost();
            desertObelisk.GoldCost = 1000000;
            desertObelisk.BuildItems.Add(new BuildItem((int) ItemID.IRIDIUM_BAR, 20));
            desertObelisk.BuildItems.Add(new BuildItem((int) ItemID.COCONUT, 10));
            desertObelisk.BuildItems.Add(new BuildItem((int) ItemID.CACTUS_FRUIT, 10));

            BlueprintCost earthObelisk = new BlueprintCost();
            earthObelisk.GoldCost = 500000;
            earthObelisk.BuildItems.Add(new BuildItem((int) ItemID.IRIDIUM_BAR, 10));
            earthObelisk.BuildItems.Add(new BuildItem((int) ItemID.EARTH_CRYSTAL, 10));

            BlueprintCost islandObelisk = new BlueprintCost();
            islandObelisk.GoldCost = 1000000;
            islandObelisk.BuildItems.Add(new BuildItem((int) ItemID.IRIDIUM_BAR, 10));
            islandObelisk.BuildItems.Add(new BuildItem((int) ItemID.BANANA, 10));
            islandObelisk.BuildItems.Add(new BuildItem((int) ItemID.DRAGON_TOOTH, 10));

            BlueprintCost waterObelisk = new BlueprintCost();
            waterObelisk.GoldCost = 500000;
            waterObelisk.BuildItems.Add(new BuildItem((int) ItemID.IRIDIUM_BAR, 5));
            waterObelisk.BuildItems.Add(new BuildItem((int) ItemID.CLAM, 10));
            waterObelisk.BuildItems.Add(new BuildItem((int) ItemID.CORAL, 10));


            Buildings.Add("Coop", coop);
            Buildings.Add("Big Coop", bigCoop);
            Buildings.Add("Deluxe Coop", deluxeCoop);
            Buildings.Add("Barn", barn);
            Buildings.Add("Big Barn", bigBarn);
            Buildings.Add("Deluxe Barn", deluxeBarn);
            Buildings.Add("Shed", shed);
            Buildings.Add("Big Shed", bigShed);
            Buildings.Add("Silo", silo);
            Buildings.Add("Mill", mill);
            Buildings.Add("Well", well);
            Buildings.Add("Fish Pond", fishPond);
            Buildings.Add("Stable", stable);
            Buildings.Add("Slime Hutch", slimeHutch);
            Buildings.Add("Shipping Bin", shippingBin);
            Buildings.Add("Cabin", cabin);

            Buildings.Add("Gold Clock", goldClock);
            Buildings.Add("Junimo Hut", junimoHut);
            Buildings.Add("Desert Obelisk", desertObelisk);
            Buildings.Add("Island Obelisk", islandObelisk);
            Buildings.Add("Earth Obelisk", earthObelisk);
            Buildings.Add("Water Obelisk", waterObelisk);
        }
    }
}
