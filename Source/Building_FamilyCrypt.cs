using RimWorld;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Verse;
using System.Linq;

namespace FamilyCrypts
{
    public class Building_FamilyCrypt : Building_Grave
    {
        private const string V = "CommandGraveAssignColonistLabel";

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
            IEnumerable<Gizmo> gizmos = ((Building_FamilyCrypt)null).GetGizmos();
            foreach (var (gizmo1, commandAction) in from Gizmo gizmo1 in gizmos
                                                    let commandAction = gizmo1 as Command_Action
                                                    select (gizmo1, commandAction))
            {
                string str;
                if (commandAction != null)
                {
                    str = commandAction.defaultLabel;
                }
                else
                {
                    str = null;
                }

                if (str == V.Translate())
                {
                    continue;
                }

                yield return gizmo1;
            }

            if (((Building_FamilyCrypt)null).StorageTabVisible)
            {
                foreach (Gizmo gizmo1 in StorageSettingsClipboard.CopyPasteGizmosFor(((Building_FamilyCrypt)null).storageSettings))
                {
                    yield return gizmo1;
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
    }
}