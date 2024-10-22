using System.Collections.Generic;
using AdjustableBuildingCosts.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.GameData.Buildings;
using StardewValley.Menus;

namespace AdjustableBuildingCosts
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {

        /// <summary>The mod configuration from the player.</summary>
        private ModConfig Config;

        private int buildingDaysLeft = 0;
        private int upgradingDaysLeft = 0;

        private bool isBuilding = false;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            this.Config = this.Helper.ReadConfig<ModConfig>();

            helper.Events.GameLoop.DayStarted += this.OnDayStarted;
            helper.Events.GameLoop.SaveLoaded += this.OnSaveLoaded;
        }

        private void OnSaveLoaded(object sender, SaveLoadedEventArgs e)
        {

            var buildings = Game1.getFarm().buildings;
            for (int i = 0; i < buildings.Count; i++) {
                if (buildings[i].daysOfConstructionLeft.Value > 0 || buildings[i].daysUntilUpgrade.Value > 0) {
                    //Monitor.Log("Setting isBuilding to true", LogLevel.Debug);
                    isBuilding = true;
                    break;
                }
            }

            foreach (KeyValuePair<string, BuildingData> entry in Game1.buildingData){
                if (Config.Buildings.ContainsKey(entry.Key)) {
                    int oldBuildCost = entry.Value.BuildCost;
                    int oldBuildDays = entry.Value.BuildDays;
                    entry.Value.BuildCost = Config.Buildings[entry.Key].GoldCost;
                    entry.Value.BuildDays = Config.Buildings[entry.Key].DaysToBuild;

                    Monitor.Log("Changed build cost of " + entry.Key + " from " + oldBuildCost + " to " + entry.Value.BuildCost, LogLevel.Trace);
                    Monitor.Log("Changed build days of " + entry.Key + " from " + oldBuildDays + " to " + entry.Value.BuildDays, LogLevel.Trace);

                    if (entry.Value.BuildMaterials != null) {
                        entry.Value.BuildMaterials.Clear();
                        foreach (BuildItem buildItem in Config.Buildings[entry.Key].BuildItems) {
                            BuildingMaterial buildingMaterial = new BuildingMaterial();
                            buildingMaterial.ItemId = buildItem.ItemId.ToString();
                            buildingMaterial.Amount = buildItem.Amount;
                            entry.Value.BuildMaterials.Add(buildingMaterial);
                            Monitor.Log("Added " + buildingMaterial.Amount + " building material with Id " + buildingMaterial.ItemId, LogLevel.Trace);
                        }
                    }
                } 
            }
        }

        private void OnDayStarted(object sender, DayStartedEventArgs e)
        {
            var buildings = Game1.getFarm().buildings;

            for (int i = 0; i < buildings.Count; i++) {
                if (buildings[i].daysOfConstructionLeft.Value > 0) {
                    // Monitor.Log("------------- Inside construction ------------", LogLevel.Debug);
                    // Monitor.Log("Building -> " + buildings[i].ToString(), LogLevel.Debug);
                    // Monitor.Log("Building -> " + buildings[i].GetIndoorsName(), LogLevel.Debug);
                    // Monitor.Log("Building -> " + buildings[i].daysUntilUpgrade.ToString(), LogLevel.Debug);
                    // Monitor.Log("Building -> " + buildings[i].daysOfConstructionLeft.ToString(), LogLevel.Debug);
                    // Monitor.Log("Building -> " + buildings[i].buildingType.Value, LogLevel.Debug);
                    // Monitor.Log("Building -> " + buildings[i].upgradeName, LogLevel.Debug);

                    buildingDaysLeft = buildings[i].daysOfConstructionLeft.Value;

                    if (!isBuilding) {
                        buildingDaysLeft = Config.Buildings[buildings[i].buildingType.Value].DaysToBuild;
                        buildings[i].daysOfConstructionLeft.Value = buildingDaysLeft;
                        isBuilding = true;

                        Monitor.Log("Setting days to construct to " + buildings[i].daysOfConstructionLeft.Value + " for " + buildings[i].buildingType.Value, LogLevel.Debug);
                        break;
                    }
                }

                if (buildings[i].daysUntilUpgrade.Value > 0) {
                    // Monitor.Log("------------ Inside upgrade -------------", LogLevel.Debug);
                    // Monitor.Log("Building -> " + buildings[i].ToString(), LogLevel.Debug);
                    // Monitor.Log("Building -> " + buildings[i].GetIndoorsName(), LogLevel.Debug);
                    // Monitor.Log("Building -> " + buildings[i].daysUntilUpgrade.ToString(), LogLevel.Debug);
                    // Monitor.Log("Building -> " + buildings[i].daysOfConstructionLeft.ToString(), LogLevel.Debug);
                    // Monitor.Log("Building -> " + buildings[i].buildingType.Value, LogLevel.Debug);
                    // Monitor.Log("Building -> " + buildings[i].upgradeName, LogLevel.Debug);

                    upgradingDaysLeft = buildings[i].daysUntilUpgrade.Value;
                    if (!isBuilding) {
                        upgradingDaysLeft = Config.Buildings[buildings[i].upgradeName.Value].DaysToBuild;
                        buildings[i].daysUntilUpgrade.Value = upgradingDaysLeft;
                        isBuilding = true;

                        Monitor.Log("Setting days to upgrade to " + buildings[i].daysUntilUpgrade.Value + " for " + buildings[i].buildingType.Value, LogLevel.Debug);
                        break;
                    }
                }

                // Monitor.Log("------------- General ------------", LogLevel.Debug);
                // Monitor.Log("Building -> " + buildings[i].ToString(), LogLevel.Debug);
                // Monitor.Log("Building -> " + buildings[i].GetIndoorsName(), LogLevel.Debug);
                // Monitor.Log("Building -> " + buildings[i].daysUntilUpgrade.ToString(), LogLevel.Debug);
                // Monitor.Log("Building -> " + buildings[i].daysOfConstructionLeft.ToString(), LogLevel.Debug);
                // Monitor.Log("Building -> " + buildings[i].buildingType.Value, LogLevel.Debug);
                // Monitor.Log("Building -> " + buildings[i].upgradeName, LogLevel.Debug);
            }

            if (upgradingDaysLeft <= 1 && buildingDaysLeft <= 1) {
                isBuilding = false;
                Monitor.Log("Resetting daysLeft", LogLevel.Debug);
                buildingDaysLeft = 0;
                upgradingDaysLeft = 0;
            }

            // Monitor.Log("isBuilding -> " + isBuilding, LogLevel.Debug);
            // Monitor.Log("upgradingDaysLeft -> " + upgradingDaysLeft, LogLevel.Debug);
            // Monitor.Log("buildingDaysLeft -> " + buildingDaysLeft, LogLevel.Debug);
        }
    }
}
