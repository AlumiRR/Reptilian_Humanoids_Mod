using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Reflection;
using Verse;
using Verse.AI;
using Verse.Noise;


namespace ReptilianHumanoidsMod
{
    [StaticConstructorOnStartup]

    public static class ReptilianHumanoidsMod
    {

        public class Load
        {
            [DefOf]
            public static class LoadDefOf
            {
                static LoadDefOf()
                {
                    DefOfHelper.EnsureInitializedInCtor(typeof(LoadDefOf));
                }

                public static GeneDef Skin_Tough;

            }
        }

    }
}