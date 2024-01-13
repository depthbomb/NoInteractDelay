using BepInEx;
using HarmonyLib;
using NoInteractDelay.Patches;

namespace NoInteractDelay
{
    [BepInPlugin(Constants.PluginGuid, Constants.Name, Constants.Version)]
    public class NoInteractDelayPlugin : BaseUnityPlugin
    {
        private readonly Harmony _harmony = new Harmony(Constants.PluginGuid);

        private void Awake()
        {
            GlobalShared.Logger.LogInfo($"Loaded {Constants.Name} v{Constants.Version}");
            
            _harmony.PatchAll(typeof(RemoveInteractionDelay));
            _harmony.PatchAll(typeof(RemoveItemUseCooldown));
        }
    }
}
