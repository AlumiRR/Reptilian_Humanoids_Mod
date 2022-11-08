using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace ReptilianHumanoidsMod
{
    public class Gene_Winter_Hibernation : Gene
    {
        public override void PostAdd()
        {
            base.PostAdd();
            this.pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("Hediff_Winter_Hibernation", true));
        }
    }
}
