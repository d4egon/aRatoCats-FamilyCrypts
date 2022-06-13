using RimWorld;
using System;
using System.Collections.Generic;
using System.Text;
using Verse;

namespace FamilyCrypts
{
	public class Building_FamilyCrypt : Building_Grave
	{
		public int CorpseCount
		{
			get
			{
				return this.innerContainer.Count;
			}
		}

		public bool CanAcceptCorpses
		{
			get
			{
				return this.CorpseCount < Controller.settings.CorpseCapacity;
			}
		}

		public int MaxAssignedPawnsCount
		{
			get
			{
				return Math.Max(1, Controller.settings.CorpseCapacity - this.CorpseCount);
			}
		}

		public override bool StorageTabVisible
		{
			get
			{
				return this.CanAcceptCorpses;
			}
		}

		public override bool Accepts(Thing thing)
		{
			return this.innerContainer.CanAcceptAnyOf(thing, true) && base.GetStoreSettings().AllowedToAccept(thing) && this.CanAcceptCorpses;
		}

		public override string GetInspectString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(base.InspectStringPartsFromComps());
			stringBuilder.Append(string.Concat(new string[]
			{
				Translator.Translate("FamilyCrypt_Capacity"),
				": ",
				this.CorpseCount.ToString(),
				"/",
				Controller.settings.CorpseCapacity.ToString()
			}));
			return stringBuilder.ToString();
		}

		public override IEnumerable<Gizmo> GetGizmos()
		{
			Building_FamilyCrypt expr_07 = new Building_FamilyCrypt();
			expr_07.<> 4__ this = this;
			return (IEnumerable<Gizmo>)expr_07;
		}
	}
}
