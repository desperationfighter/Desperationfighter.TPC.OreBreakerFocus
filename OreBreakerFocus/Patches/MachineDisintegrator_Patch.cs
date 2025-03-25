using HarmonyLib;
using RecycletoInventory;
using SpaceCraft;

/*
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Instance Name> OreBreaker1(Clone)
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Intervall Spawn set to - 130 - before
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Set Tier 1 Intervall - 80
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Intervall Spawn set to - 130 - after
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Instance Name> OreBreaker1(Clone)
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Break into Pieces set to - 3 - before
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Set Tier 1 Breaker how many Ores - 3
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Breaker how many Ores set to - 3 - after

[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Instance Name> OreBreaker2(Clone)
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Intervall Spawn set to - 90 - before
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Set Tier 2 Intervall - 75
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Intervall Spawn set to - 90 - after
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Instance Name> OreBreaker2(Clone)
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Break into Pieces set to - 4 - before
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Set Tier 2 Breaker how many Ores - 4
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Breaker how many Ores set to - 4 - after

[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Instance Name> OreBreaker3(Clone)
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Intervall Spawn set to - 70 - before
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Set Tier 3 Intervall - 75
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Intervall Spawn set to - 70 - after
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Instance Name> OreBreaker3(Clone)
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Break into Pieces set to - 5 - before
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Set Tier 3 Breaker how many Ores - 5
[Debug  :Ore Breaker Focus] [Ore Breaker Focus]:(MachineDisintegrator) : Breaker how many Ores set to - 5 - after
 */

namespace OreBreakerFocus.Patches
{
    [HarmonyPatch(typeof(MachineDisintegrator))]
    static public class MachineDisintegrator_Patch
    {
        static public bool loadedonce;

        static public void SettoOriginal_tick(MachineDisintegrator __instance)
        {
            if (!__instance.name.Contains("OreBreaker1"))
            {
                Plugin.MyDebugLogger($"(MachineDisintegrator) : Set Tier 1 Intervall back to Orignal");

                __instance.breakEveryXSec = Plugin.OriginalBreakIntervaltier1;
            }
            else if (!__instance.name.Contains("OreBreaker2"))
            {
                Plugin.MyDebugLogger($"(MachineDisintegrator) : Set Tier 2 Intervall back to Orignal");
                __instance.breakEveryXSec = Plugin.OriginalBreakIntervaltier2;
            }
            else if (!__instance.name.Contains("OreBreaker3"))
            {
                Plugin.MyDebugLogger($"(MachineDisintegrator) : Set Tier 3 Intervall back to Orignal");
                __instance.breakEveryXSec = Plugin.OriginalBreakIntervaltier3;
            }
        }

        static public void SettoOriginal_XIngredientsBack(MachineDisintegrator __instance)
        {
            if (__instance.name.Contains("OreBreaker1"))
            {
                Plugin.MyDebugLogger($"(MachineDisintegrator) : Set Tier 1 Breaker how many Ores - back to Orignal");
                __instance.giveXIngredientsBack = Plugin.OriginalBreakintoPartstier1;
            }
            else if (__instance.name.Contains("OreBreaker2"))
            {
                Plugin.MyDebugLogger($"(MachineDisintegrator) : Set Tier 2 Breaker how many Ores - back to Orignal");
                __instance.giveXIngredientsBack = Plugin.OriginalBreakintoPartstier2;
            }
            else if (__instance.name.Contains("OreBreaker3"))
            {
                Plugin.MyDebugLogger($"(MachineDisintegrator) : Set Tier 3 Breaker how many Ores - back to Orignal");
                __instance.giveXIngredientsBack = Plugin.OriginalBreakintoPartstier3;
            }
        }

        static public void SettoModded_tick(MachineDisintegrator __instance)
        {
            Plugin.MyDebugLogger($"(MachineDisintegrator) : Instance Name> {__instance.name}");
            Plugin.MyDebugLogger($"(MachineDisintegrator) : Intervall Spawn set to - {__instance.breakEveryXSec} - before");

            if (__instance.name.Contains("OreBreaker1"))
            {
                Plugin.MyDebugLogger($"(MachineDisintegrator) : Set Tier 1 Intervall - {Plugin.BreakIntervaltier1.Value}");
                __instance.breakEveryXSec = Plugin.BreakIntervaltier1.Value;
            }
            else if (__instance.name.Contains("OreBreaker2"))
            {
                Plugin.MyDebugLogger($"(MachineDisintegrator) : Set Tier 2 Intervall - {Plugin.BreakIntervaltier2.Value}");
                __instance.breakEveryXSec = Plugin.BreakIntervaltier2.Value;
            }
            else if (__instance.name.Contains("OreBreaker3"))
            {
                Plugin.MyDebugLogger($"(MachineDisintegrator) : Set Tier 3 Intervall - {Plugin.BreakIntervaltier3.Value}");
                __instance.breakEveryXSec = Plugin.BreakIntervaltier3.Value;
            }

            Plugin.MyDebugLogger($"(MachineDisintegrator) : Intervall Spawn set to - {__instance.breakEveryXSec} - after");
        }

        static public void SettoModded_XIngredientsBack(MachineDisintegrator __instance)
        {
            Plugin.MyDebugLogger($"(MachineDisintegrator) : Instance Name> {__instance.name}");
            Plugin.MyDebugLogger($"(MachineDisintegrator) : Break into Pieces set to - {__instance.giveXIngredientsBack} - before");

            if (__instance.name.Contains("OreBreaker1"))
            {
                Plugin.MyDebugLogger($"(MachineDisintegrator) : Set Tier 1 Breaker how many Ores - {Plugin.BreakintoPartstier1.Value}");
                __instance.giveXIngredientsBack = Plugin.BreakintoPartstier1.Value;
            }
            else if (__instance.name.Contains("OreBreaker2"))
            {
                Plugin.MyDebugLogger($"(MachineDisintegrator) : Set Tier 2 Breaker how many Ores - {Plugin.BreakintoPartstier2.Value}");
                __instance.giveXIngredientsBack = Plugin.BreakintoPartstier2.Value;
            }
            else if (__instance.name.Contains("OreBreaker3"))
            {
                Plugin.MyDebugLogger($"(MachineDisintegrator) : Set Tier 3 Breaker how many Ores - {Plugin.BreakintoPartstier3.Value}");
                __instance.giveXIngredientsBack = Plugin.BreakintoPartstier3.Value;
            }

            Plugin.MyDebugLogger($"(MachineDisintegrator) : Breaker how many Ores set to - {__instance.giveXIngredientsBack} - after");
        }
}

    //Hook in Initial where the Developer Manipulate the Tick, so that should be safe.
    [HarmonyPatch(typeof(MachineDisintegrator))]
    [HarmonyPatch(nameof(MachineDisintegrator.SetDisintegratorInventory))]
    static class MachineDisintegrator_SetDisintegratorInventory_Patch
    {
        [HarmonyPrefix]
        static bool Prefix(MachineDisintegrator __instance)
        {
            if (!Plugin.ModisActive.Value)
            {
                return true;
            }
            //Make sure to only Patch the Extractors
            if (!__instance.name.Contains("OreBreaker")) return true;
            if (!MachineDisintegrator_Patch.loadedonce)
            {
                MachineDisintegrator_Patch.loadedonce = true;
            }
            //Set Tick to Modded one
            if (Plugin.ModifyTick.Value)
            {
                MachineDisintegrator_Patch.SettoModded_tick(__instance);
            }
            else
            {
                MachineDisintegrator_Patch.SettoOriginal_tick(__instance);
            }
            //Set Break to Modded one
            if(Plugin.ModifyBreakintoXParts.Value) 
            {
                MachineDisintegrator_Patch.SettoModded_XIngredientsBack(__instance);
            }
            else
            {
                MachineDisintegrator_Patch.SettoOriginal_XIngredientsBack(__instance);
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(MachineDisintegrator))]
    [HarmonyPatch(nameof(MachineDisintegrator.TryToDesintegrateAnObjectInInventory))]
    static class MachineDisintegrator_TryToDesintegrateAnObjectInInventory_Patch
    {
        [HarmonyPrefix]
        static bool Prefix(MachineDisintegrator __instance)
        {
            if (!__instance.name.Contains("OreBreaker")) return true;

            if (!Plugin.ModisActive.Value)
            {
                if (MachineDisintegrator_Patch.loadedonce)
                {
                    MachineDisintegrator_Patch.SettoOriginal_tick(__instance);
                    MachineDisintegrator_Patch.SettoOriginal_XIngredientsBack(__instance);
                }
                return true;
            }
            
            MachineDisintegrator_Patch.loadedonce = true;
            //Set Tick to Modded one
            if (Plugin.ModifyTick.Value)
            {
                MachineDisintegrator_Patch.SettoModded_tick(__instance);
            }
            else
            {
                MachineDisintegrator_Patch.SettoOriginal_tick(__instance);
            }
            //Set Break to Modded one
            if (Plugin.ModifyBreakintoXParts.Value)
            {
                MachineDisintegrator_Patch.SettoModded_XIngredientsBack(__instance);
            }
            else
            {
                MachineDisintegrator_Patch.SettoOriginal_XIngredientsBack(__instance);
            }
            return true;
        }
    }
}
