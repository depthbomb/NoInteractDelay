using BepInEx;
using HarmonyLib;
using BepInEx.Configuration;
using NoInteractDelay.Patches;

namespace NoInteractDelay
{
    [BepInPlugin(Constants.PluginGuid, Constants.Name, Constants.Version)]
    public class NoInteractDelayPlugin : BaseUnityPlugin
    {
        private ConfigEntry<bool> _removeWorldObjectDelay;
        private ConfigEntry<bool> _removeHeldItemUseDelay;

        private readonly Harmony _harmony = new Harmony(Constants.PluginGuid);

        private void Awake()
        {
            GlobalShared.Logger.LogInfo($"Loaded {Constants.Name} v{Constants.Version}");

            _removeWorldObjectDelay = Config.Bind("General", "RemoveWorldObjectDelay", true, "Whether to remove the delay between interacting with objects in the world (buttons, company bell, etc.)");
            _removeHeldItemUseDelay = Config.Bind("General", "RemoveHeldItemUseDelay", true, "Whether to remove the delay between using items you are holding (air horn, clown horn, etc.)");

            if (_removeWorldObjectDelay.Value)
            {
                _harmony.PatchAll(typeof(RemoveInteractionDelay));

                GlobalShared.Logger.LogInfo("Applied patch for world object use");
            }

            if (_removeHeldItemUseDelay.Value)
            {
                _harmony.PatchAll(typeof(RemoveItemUseCooldown));

                GlobalShared.Logger.LogInfo("Applied patch for held item use");
            }
        }
    }
}
