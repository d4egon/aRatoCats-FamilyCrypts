using HarmonyLib;
using RimWorld;
using System;

namespace FamilyCrypts
{
	[HarmonyPatch(typeof(Building_Grave), "StorageTabVisible", MethodType.Getter)]
	public static class Harmony_Storage_Tab_Visible
	{
		public static bool Prefix(Building_Grave __instance, ref bool __result)
		{
			Building_FamilyCrypt building_FamilyCrypt;
			if ((building_FamilyCrypt = (__instance as Building_FamilyCrypt)) != null)
			{
				__result = building_FamilyCrypt.StorageTabVisible;
				return false;
			}
			return true;
		}
	}
}
