using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using UnityEngine.Assertions.Must;
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
            harmony.Patch(AccessTools.Method(typeof(WorldObject), "PostAdd", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "WorldObject_PostAdd_PostFix", null), null, null);
        }

        //Turns skin from butchering of pawn with Tohugh Skin gene into lizard skin

        private static void ButcherProducts_PostFix(Pawn __instance, ref IEnumerable<Thing> __result)
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

        private static void WorldObject_PostAdd_PostFix(WorldObject __instance)
        {
            bool toBeDeleted = false;
            try
            {
                if (__instance.Faction.def.xenotypeSet.Contains(DefDatabase<XenotypeDef>.GetNamed("Lizardfolk", false)))
                {
                    for (int i = 0; i < __instance.Faction.def.xenotypeSet.Count; i++)
                    {
                        if (__instance.Faction.def.xenotypeSet[i].xenotype == DefDatabase<XenotypeDef>.GetNamed("Lizardfolk", false))
                        {
                            if(__instance.Faction.def.xenotypeSet[i].chance > 0.5 & __instance.Biome.defName != "TropicalRainforest" & __instance.Biome.defName != "TropicalSwamp")
                                toBeDeleted = true;
                        }
                    }
                }
            }
            catch
            { }
            if(toBeDeleted)
            {
                __instance.Destroy();
            }
        }

    }
}
