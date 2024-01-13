using BepInEx.Logging;

namespace NoInteractDelay
{
    public static class GlobalShared
    {
        public static readonly ManualLogSource Logger = BepInEx.Logging.Logger.CreateLogSource(Constants.PluginGuid);
    }
}
