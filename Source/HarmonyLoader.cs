using HarmonyLib;
using System;
using System.Reflection;
using Verse;

namespace FamilyCrypts
{
	[StaticConstructorOnStartup]
	public static class HarmonyLoader
	{
		static HarmonyLoader()
		{
			new Harmony("FamilyCrypts.Harmony").PatchAll(Assembly.GetExecutingAssembly());
		}
	}
}
