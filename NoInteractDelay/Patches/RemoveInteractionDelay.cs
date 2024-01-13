using HarmonyLib;

namespace NoInteractDelay.Patches
{
    [HarmonyPatch(typeof(InteractTrigger), "Interact")]
    public class RemoveInteractionDelay
    {
        // ReSharper disable once InconsistentNaming
        public static bool Prefix(InteractTrigger __instance)
        {
            __instance.interactCooldown = false;

            return true;
        }
    }
}
