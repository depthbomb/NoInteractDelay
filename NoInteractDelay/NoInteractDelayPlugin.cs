using BepInEx;
using HarmonyLib;
using BepInEx.Logging;
using NoInteractDelay.Patches;

namespace NoInteractDelay
{
    [BepInPlugin(Constants.PluginGuid, Constants.Name, Constants.Version)]
    public class NoInteractDelayPlugin : BaseUnityPlugin
    {
        public static NoInteractDelayPlugin Instance;

        private readonly Harmony _harmony = new Harmony(Constants.PluginGuid);

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            
            GlobalShared.Logger.LogInfo($"Loaded {Constants.Name} v{Constants.Version}");
            
            _harmony.PatchAll(typeof(RemoveInteractionDelay));
            _harmony.PatchAll(typeof(RemoveItemUseCooldown));
        }
    }
}
