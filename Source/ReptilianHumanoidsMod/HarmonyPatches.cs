using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace ReptilianHumanoidsMod
{
    [StaticConstructorOnStartup]
    internal static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            Harmony harmony = new Harmony("alumirr.reptilianhm");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            harmony.Patch(AccessTools.Method(typeof(Pawn), "ButcherProducts", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "ButcherProducts_PostFix", null), null, null);
        }

        //Turns skin from butchering of pawn with Tohugh Skin gene into lizard skin

        private static void ButcherProducts_PostFix(Pawn __instance, ref IEnumerable<Thing> __result, float efficiency)
        {
            Log.Message("ttt");
            List<Thing> list = new List<Thing>();
            foreach (Thing thing in __result)
            {
                if(thing.def == DefDatabase<ThingDef>.GetNamed("Leather_Human", true))
                    if(__instance.genes.HasGene(DefDatabase<GeneDef>.GetNamed("Skin_Tough", false)))
                    {
                        thing.def = DefDatabase<ThingDef>.GetNamed("Leather_Lizard", true);
                    }
                list.Add(thing);
            }
            IEnumerable<Thing> topass = list;
            __result = topass;
        }
    }
}
