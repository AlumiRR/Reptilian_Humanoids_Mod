using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace ReptilianHumanoidsMod
{
    public class Hediff_Winter_Hibernation : Hediff
    {
        public override void Tick()
        {
            base.Tick();
            if (this.pawn.IsHashIntervalTick(2000))
            {
                float Temperature = this.pawn.AmbientTemperature;
                float TempDiff = this.pawn.ComfortableTemperatureRange().min - Temperature + 25.0f;
                if (TempDiff > 2.5f && Severity <= 0.2f)
                {
                    Severity += 0.001f * TempDiff;
                }
                if (TempDiff > 10f && Severity <= 0.5f)
                {
                    Severity += 0.001f * TempDiff;
                }
                if (TempDiff > 20f && Severity <= 1f)
                {
                    Severity += 0.001f * TempDiff;
                }
                if (TempDiff < -1f)
                {
                    Severity += 0.001f * TempDiff;
                }

            }
            if (this.pawn.IsHashIntervalTick(100000))
            {
                
            }    
        }
    }
}
