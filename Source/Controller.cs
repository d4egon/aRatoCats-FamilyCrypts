using System;
using UnityEngine;
using Verse;

namespace FamilyCrypts
{
	public class Controller : Mod
	{
		public static Settings settings;

		public Controller(ModContentPack content) : base(content)
		{
			Controller.settings = base.GetSettings<Settings>();
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			Controller.settings.DoWindowContents(inRect);
		}

		public override string SettingsCategory()
		{
			return Translator.Translate("FamilyCrypt_Settings");
		}

	}
}
