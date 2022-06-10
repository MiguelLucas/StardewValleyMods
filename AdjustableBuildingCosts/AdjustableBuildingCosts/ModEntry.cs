using System;
using System.Collections;
using System.Collections.Generic;
using AdjustableBuildingCosts.Framework;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Buildings;
using StardewValley.Menus;
using StardewValley.Tools;

namespace AdjustableBuildingCosts
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {

        /// <summary>The mod configuration from the player.</summary>
        private ModConfig Config;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            this.Config = this.Helper.ReadConfig<ModConfig>();

            
            this.Monitor.Log(Config.Silo.ToString(), LogLevel.Info);

            IDictionary<string, string> data = helper.GameContent.Load<Dictionary<string, string>>("Data/Blueprints");


            foreach (string key in data.Keys) {
                string line = data[key];

                this.Monitor.Log(line, LogLevel.Info);
            }

            helper.Events.Content.AssetRequested += this.OnAssetRequested;
            //helper.Events.Display.MenuChanged += this.OnMenuChanged;
        }


        /*********
        ** Private methods
        *********/

        /// <inheritdoc cref="IContentEvents.AssetRequested"/>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnAssetRequested(object sender, AssetRequestedEventArgs e)
        {
            if (e.NameWithoutLocale.IsEquivalentTo("Data/Blueprints")) {
                e.Edit(asset =>
                {
                    var data = asset.AsDictionary<string, string>().Data;


                    foreach (string itemID in data.Keys) {
                        
                        this.Monitor.Log("Before -> " + data[itemID], LogLevel.Info);

                        string[] fields = data[itemID].Split('/');

                        if (fields.Length > 8) {
                            string name = fields[8];
                            string formattedCost = "";

                            //this.Monitor.Log("Before name -> " + name, LogLevel.Info);
                            switch (name) {
                                case "Silo":
                                    formattedCost = Config.Silo.getFormattedBlueprintCost();
                                    break;
                                default:
                                    //maintain current cost
                                    formattedCost = fields[0];
                                    break;
                            }
                            //this.Monitor.Log("After cost -> " + formattedCost, LogLevel.Info);
                            fields[0] = formattedCost;
                            data[itemID] = string.Join("/", fields);

                            
                        }
                        this.Monitor.Log("After -> " + data[itemID], LogLevel.Info);
                    }
                });
            }
        }

        /// <inheritdoc cref="IDisplayEvents.MenuChanged"/>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnMenuChanged(object? sender, MenuChangedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            this.Monitor.Log("Menu full name -> " + e.NewMenu?.GetType().FullName, LogLevel.Info);
            this.Monitor.Log("Menu class -> " + e.NewMenu?.GetType().Name, LogLevel.Info);


            //return;
            

            /*if (e.NewMenu is ShopMenu) {
                // get field
                IList<BluePrint> blueprints = this.Helper.Reflection
                    .GetField<List<BluePrint>>(e.NewMenu, "blueprints")
                    .GetValue();

                foreach (BluePrint bluePrint in blueprints) {
                    this.Monitor.Log("Blueprint #" + bluePrint.displayName, LogLevel.Info);
                }
            }*/


            // add blueprints
            if (e.NewMenu is CarpenterMenu) {
                // get field
                IList<BluePrint> blueprints = this.Helper.Reflection
                    .GetField<List<BluePrint>>(e.NewMenu, "blueprints")
                    .GetValue();

                this.Monitor.Log("How many blueprints -> " + blueprints.Count, LogLevel.Info);
                

                

                foreach (BluePrint bluePrint in blueprints) {
                    this.Monitor.Log("Blueprint #" + bluePrint.displayName, LogLevel.Info);

                    bluePrint.moneyRequired = 10;
                    bluePrint.daysToConstruct = 7;
                    bluePrint.woodRequired = 0;
                    

                }

                ((CarpenterMenu) e.NewMenu).setNewActiveBlueprint();
                // add garage blueprint
                //blueprints.Add(this.GetBlueprint());


            }
        }
    }
}
