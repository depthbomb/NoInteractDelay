﻿using HarmonyLib;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedParameter.Global

namespace NoInteractDelay.Patches
{
    [HarmonyPatch(typeof(GrabbableObject), "RequireCooldown")]
    public class RemoveItemUseCooldown
    {
        public static bool Prefix(GrabbableObject __instance, ref bool __result)
        {
            __result = false;

            return false;
        }
    }
}
