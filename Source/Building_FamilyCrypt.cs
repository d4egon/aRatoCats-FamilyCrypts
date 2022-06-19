using RimWorld;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Verse;

namespace FamilyCrypts
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Building_FamilyCrypt : Building_Grave
    {
        public bool CanAcceptCorpses => CorpseCount < Controller.settings.CorpseCapacity;

        public int CorpseCount => innerContainer.Count;

        public int MaxAssignedPawnsCount => Math.Max(1, Controller.settings.CorpseCapacity - CorpseCount);

        public override bool StorageTabVisible => CanAcceptCorpses;

        public Building_FamilyCrypt()
        {
        }

        public override bool Accepts(Thing thing)
        {
            if (!innerContainer.CanAcceptAnyOf(thing, true) || !GetStoreSettings().AllowedToAccept(thing))
            {
                return false;
            }
            return CanAcceptCorpses;
        }



        public override IEnumerable<Gizmo> GetGizmos()
        {
            var gizmos = base.GetGizmos();
            foreach (var gizmo in gizmos)
            {
                if (gizmo is Command_Action commandAction && commandAction.defaultLabel == "CommandGraveAssignColonistLabel".Translate())
                {
                    continue;
                }
                
                yield return gizmo;
            }

            if (StorageTabVisible)
            {
                foreach (var gizmo in StorageSettingsClipboard.CopyPasteGizmosFor(storageSettings))
                {
                    yield return gizmo;
                }
            }
        }
            
        

        public override string GetInspectString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(InspectStringPartsFromComps());
            string[] str = new string[] { "FamilyCrypt_Capacity".Translate(), ": ", null, null, null };
            int corpseCount = CorpseCount;
            str[2] = corpseCount.ToString();
            str[3] = "/";
            corpseCount = Controller.settings.CorpseCapacity;
            str[4] = corpseCount.ToString();
            stringBuilder.Append(string.Concat(str));
            return stringBuilder.ToString();
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}