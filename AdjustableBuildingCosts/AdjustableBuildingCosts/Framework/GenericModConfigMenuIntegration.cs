using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using StardewModdingAPI;

namespace AdjustableBuildingCosts.Framework
{
    /// <summary>Registers the mod configuration with Generic Mod Config Menu.</summary>
    internal class GenericModConfigMenuIntegration
    {
        /*********
        ** Fields
        *********/
        /// <summary>The CJB Cheats Menu manifest.</summary>
        private readonly IManifest Manifest;

        /// <summary>The Generic Mod Config Menu integration.</summary>
        private readonly IGenericModConfigMenuApi? ConfigMenu;

        /// <summary>The current mod settings.</summary>
        private readonly ModConfig Config;

        /// <summary>Save the mod's current config to the <c>config.json</c> file.</summary>
        private readonly Action Save;


        /*********
        ** Public methods
        *********/
        /// <summary>Construct an instance.</summary>
        /// <param name="manifest">The CJB Cheats Menu manifest.</param>
        /// <param name="modRegistry">An API for fetching metadata about loaded mods.</param>
        /// <param name="config">Get the current mod config.</param>
        /// <param name="save">Save the mod's current config to the <c>config.json</c> file.</param>
        public GenericModConfigMenuIntegration(IManifest manifest, IModRegistry modRegistry, ModConfig config, Action save)
        {
            this.Manifest = manifest;
            this.ConfigMenu = modRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            this.Config = config;
            this.Save = save;
        }

        /// <summary>Register the config menu if available.</summary>
        public void Register()
        {
            //Monitor.Log("Registering mod config menu");

            var menu = this.ConfigMenu;
            if (menu is null)
                return;

            menu.Register(this.Manifest, this.Reset, this.Save);

            menu.SetTitleScreenOnlyForNextOptions(
                mod: this.Manifest,
                titleScreenOnly: true
            );

            foreach (KeyValuePair<string, BlueprintCost> entry in Config.Buildings){
                menu.AddSectionTitle(this.Manifest, () => entry.Key);

                menu.AddNumberOption(
                    mod: this.Manifest,
                    name: () => "Build Cost",
                    getValue: () => entry.Value.GoldCost,
                    setValue: value => entry.Value.GoldCost = value
                );

                menu.AddNumberOption(
                    mod: this.Manifest,
                    name: () => "Build Days",
                    getValue: () => entry.Value.DaysToBuild,
                    setValue: value => entry.Value.DaysToBuild = value
                );

                menu.AddPageLink(
                    mod: this.Manifest,
                    pageId: entry.Key,
                    text: () => entry.Key + " Build Materials"
                );
            }

            foreach (KeyValuePair<string, BlueprintCost> entry in Config.Buildings){

                menu.AddPage(
                    mod: this.Manifest,
                    pageId: entry.Key,
                    pageTitle: () => entry.Key + " Build Materials"
                );

                int buildItemNo = 1;

                for (int i = 0;i < 5;i++) {
                    if (i >= entry.Value.BuildItems.Count) {
                        // add empty built item, to allow placeholder in the GMCM for more items
                        entry.Value.BuildItems.Add(new BuildItem(-1, -1));
                    }
                    BuildItem buildItem = entry.Value.BuildItems[i];
                    int currentItemNo = buildItemNo;  // Local copy so that lambda uses value and not reference
                    menu.AddSectionTitle(this.Manifest, () => "Build Item #" + currentItemNo);

                    menu.AddNumberOption(
                        mod: this.Manifest,
                        name: () => "Item Id",
                        getValue: () => buildItem.ItemId,
                        setValue: value => buildItem.ItemId = value
                    );

                    menu.AddNumberOption(
                        mod: this.Manifest,
                        name: () => "Amount",
                        getValue: () => buildItem.Amount,
                        setValue: value => buildItem.Amount = value
                    );

                    buildItemNo++;
                }
            }
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Reset the mod's config to its default values.</summary>
        private void Reset()
        {
            /*ModConfig config = this.Config;
            ModConfig defaults = new();

            config.OpenMenuKey = defaults.OpenMenuKey;
            config.FreezeTimeKey = defaults.FreezeTimeKey;
            config.GrowTreeKey = defaults.GrowTreeKey;
            config.GrowCropsKey = defaults.GrowCropsKey;

            config.DefaultTab = defaults.DefaultTab;*/
        }
    }
}