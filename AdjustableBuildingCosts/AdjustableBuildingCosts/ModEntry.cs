using System;
using System.Collections;
using System.Collections.Generic;
using AdjustableUpgradeCosts.Framework;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Buildings;
using StardewValley.Menus;
using StardewValley.Tools;

namespace AdjustableUpgradeCosts
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {

        /// <summary>The mod configuration from the player.</summary>
        private ModConfig Config;
        /// <summary>The full type name for the Pelican Fiber mod's construction menu.</summary>
        private readonly string PelicanFiberMenuFullName = "PelicanFiber.Framework.ConstructionMenu";

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            this.Config = this.Helper.ReadConfig<ModConfig>();
            BluePrint bluePrint;


            helper.Events.Input.ButtonPressed += this.OnButtonPressed;

            IDictionary<string, string> data = helper.GameContent.Load<Dictionary<string, string>>("Data/Blueprints");


            foreach (string key in data.Keys) {
                string line = data[key];

                this.Monitor.Log(line, LogLevel.Info);
            }

            helper.Events.Content.AssetRequested += this.OnAssetRequested;
            helper.Events.Display.MenuChanged += this.OnMenuChanged;
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Raised after the player presses a button on the keyboard, controller, or mouse.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;

            // print button presses to the console window
            this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}.", LogLevel.Debug);
        }

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
                        fields[0] = "390 500 330 25 334 50";
                        fields[0] = "390 1";
                        data[itemID] = string.Join("/", fields);

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


            ToolStuff(e);
            return;
            

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
            if (e.NewMenu is CarpenterMenu || e.NewMenu?.GetType().FullName == this.PelicanFiberMenuFullName) {
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

        private void ToolStuff(MenuChangedEventArgs e)
        {
            if (!(e.NewMenu is ShopMenu)) {
                return;
            }
            this.Monitor.Log("Aqui", LogLevel.Info);
            ShopMenu menu = e.NewMenu as ShopMenu;
            List<int> categories = this.Helper.Reflection.GetField<List<int>>(menu, "categoriesToSellHere").GetValue();
            if (!categories.Contains(StardewValley.Object.GemCategory) || !categories.Contains(StardewValley.Object.mineralsCategory) || !categories.Contains(StardewValley.Object.metalResources)) {
                return;
            }

            this.Monitor.Log("Aqui2", LogLevel.Info);
            Farmer who = Game1.player;

            Tool toolFromName1 = who.getToolFromName("Axe");
            Tool toolFromName2 = who.getToolFromName("Watering Can");
            Tool toolFromName3 = who.getToolFromName("Pickaxe");
            Tool toolFromName4 = who.getToolFromName("Hoe");
            Tool tool;

            List<ISalable> forSale = menu.forSale;
            Dictionary<ISalable, int[]> stock = menu.itemPriceAndStock;

            foreach (Item item in forSale) {
                this.Monitor.Log("ForSale #" + item.DisplayName, LogLevel.Info);
            }

            foreach (KeyValuePair<ISalable, int[]> entry in stock) {
                this.Monitor.Log("Stock Key #" + entry.Key.DisplayName, LogLevel.Info);
                this.Monitor.Log("Stock Value Lenght" + entry.Value.Length, LogLevel.Info);

                for (int i = 0; i < entry.Value.Length; i++) {
                    this.Monitor.Log("Stock Value #" + entry.Value[i], LogLevel.Info);
                }
            }

            /*if (toolFromName1 != null && toolFromName1.UpgradeLevel == 4) {
                tool = new Axe { UpgradeLevel = 5 };
                forSale.Add(tool);
                stock.Add(tool, new int[3] { UpgradeCost, 1, PrismaticBarItem.INDEX });
            }*/
        }
    }
}
