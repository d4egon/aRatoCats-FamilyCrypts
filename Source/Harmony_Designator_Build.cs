using HarmonyLib;
using RimWorld;
using System;

namespace FamilyCrypts
{
	[HarmonyPatch(typeof(Designator_Build), "Visible", MethodType.Getter)]
	public static class Harmony_Designator_Build
	{
		public static bool Prefix(Designator_Build __instance, ref bool __result)
		{
			if ((__instance.PlacingDef == GraveDefOf.FamilyCrypt && Controller.settings.UseAlt) || (__instance.PlacingDef == GraveDefOf.FamilyCryptAlt && !Controller.settings.UseAlt))
			{
				__result = false;
				return false;
			}
			return true;
		}
	}
}
