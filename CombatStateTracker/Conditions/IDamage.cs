using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatStateTracker.Conditions
{
	interface IDamage
	{
		uint Damage { get; set; }

		bool IgnoresArmor { get; set; }

		bool IgnoresToughness { get; set; }

		Combatants.HitLocations Location { get; set; }
	}
}
