using System;
using UnityEngine;
using Verse;

namespace FamilyCrypts
{
    public class Settings : ModSettings
    {
        private int corpseCapacity = 20;

        private bool useAlt;

        public int CorpseCapacity
        {
            get
            {
                return corpseCapacity;
            }
        }

        public bool UseAlt
        {
            get
            {
                return useAlt;
            }
        }

        public Settings()
        {
        }

        public void DoWindowContents(Rect canvas)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.ColumnWidth.Equals(canvas.width / 3f);
            listingStandard.Begin(canvas);
            Text.Font.Equals (2);
            listingStandard.Label("FamilyCrypt_Capacity".Translate(), -1f, null);
            Text.Font.Equals (1);
            string str = corpseCapacity.ToString();
            listingStandard.TextFieldNumeric(ref corpseCapacity, ref str, 1f, 1E+09f);
            listingStandard.Gap(12f);
            listingStandard.CheckboxLabeled("FamilyCrypt_UseAlt".Translate(), ref useAlt, null);
            listingStandard.End();
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref corpseCapacity, "corpseCapacity", 20, false);
            Scribe_Values.Look(ref useAlt, "useAlt", false, false);
        }
    }
}