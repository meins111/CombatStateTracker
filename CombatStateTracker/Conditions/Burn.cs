using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatStateTracker.Conditions
{
	public class Burn : IFixedLengthCondition, IDamage
	{
		public Burn ()
		{
			RoundsLeft = 0;
			MaxRounds = 0;
			Name = "Burn";
			Description = "Target is burning, taking damage each round.";
			Damage = 0;
			IgnoresArmor = true;
			IgnoresToughness = true;
			Location = Combatants.HitLocations.Body;
		}

		public Burn (int maxRounds, uint damage, string description = null)
			: base()
		{
			MaxRounds = maxRounds;
			Damage = damage;
			if (description != null) Description = description;
		}

		public int RoundsLeft { get; set; }
		public int MaxRounds { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public uint Damage { get; set; }
		public bool IgnoresArmor { get; set; }
		public bool IgnoresToughness { get; set; }
		public Combatants.HitLocations Location { get; set; }

		public void ResetDuration()
		{
			RoundsLeft = MaxRounds;
		}

		public string Print()
		{
			return $"Burn ({Damage}, {RoundsLeft})";
		}
	}
}
