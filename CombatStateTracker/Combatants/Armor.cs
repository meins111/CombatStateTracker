using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatStateTracker.Combatants
{
	public enum HitLocations { Head = 0, ArmLeft = 1, ArmRight = 2, Body = 3, LegLeft = 4, LegRight = 5 };

	class Armor
	{
		uint Head { get; set; }
		uint ArmLeft { get; set; }
		uint ArmRight { get; set; }
		uint Body { get; set; }
		uint LegLeft { get; set; }
		uint LegRight { get; set; }

		uint HitLocation2AP (HitLocations loc)
		{
			switch (loc)
			{
				case HitLocations.Head: return Head;
				case HitLocations.ArmLeft: return ArmLeft;
				case HitLocations.ArmRight: return ArmRight;
				case HitLocations.Body: return Body;
				case HitLocations.LegLeft: return LegLeft;
				case HitLocations.LegRight: return LegRight;
				default: return Body;
			}
		}

		void SetAllAP (uint ap)
		{
			Head = ap;
			ArmLeft = ap;
			ArmRight = ap;
			Body = ap;
			LegLeft = ap;
			LegRight = ap;
		}
	}
}
