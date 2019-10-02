using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatStateTracker.Conditions
{
	public class Bleed : IVarLengthCondition, IDamage
	{
		public Bleed ()
		{
			Name = "Bleed";
			Description = "The target has one or several bleeding wounds.";
			ChanceToEnd = 15;
			UtbDoublesChance = true;
			Damage = 0;
			IgnoresArmor = true;
			IgnoresToughness = true;
			Ongoing = true;
			Location = Combatants.HitLocations.Body;
		}

		public uint ChanceToEnd { get; set; }
		public bool UtbDoublesChance { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public uint Damage { get; set; }
		public bool IgnoresArmor { get; set; }
		public bool IgnoresToughness { get; set; }
		public bool Ongoing { get; set; }
		public Combatants.HitLocations Location { get; set; }

		public string Print()
		{
			return $"Bleed({Damage})";
		}
	}
}
