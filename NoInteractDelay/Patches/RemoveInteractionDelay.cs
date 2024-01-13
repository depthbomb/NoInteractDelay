using HarmonyLib;

// ReSharper disable InconsistentNaming

namespace NoInteractDelay.Patches
{
    [HarmonyPatch(typeof(InteractTrigger), "Interact")]
    public class RemoveInteractionDelay
    {
        public static bool Prefix(InteractTrigger __instance)
        {
            __instance.interactCooldown = false;

            return true;
        }
    }
}
