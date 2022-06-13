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
				return this.corpseCapacity;
			}
		}

		public bool UseAlt
		{
			get
			{
				return this.useAlt;
			}
		}

		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look<int>(ref this.corpseCapacity, "corpseCapacity", 20, false);
			Scribe_Values.Look<bool>(ref this.useAlt, "useAlt", false, false);
		}

		public void DoWindowContents(Rect canvas)
		{
			Listing_Standard expr_05 = new Listing_Standard();
			expr_05.ColumnWidth(canvas.width / 3f);
			expr_05.Begin(canvas);
			Text.set_Font(2);
			expr_05.Label(Translator.Translate("FamilyCrypt_Capacity"), -1f, null);
			Text.set_Font(1);
			string text = this.corpseCapacity.ToString();
			expr_05.TextFieldNumeric<int>(ref this.corpseCapacity, ref text, 1f, 1E+09f);
			expr_05.Gap(12f);
			expr_05.CheckboxLabeled(Translator.Translate("FamilyCrypt_UseAlt"), ref this.useAlt, null);
			expr_05.End();
		}
	}
}
