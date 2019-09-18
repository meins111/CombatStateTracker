using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatStateTracker.Combatants
{
	class IDamageOverTime : ICondition
	{
		public string Name { get; set; }
		public int RoundsLeft { get; set; }
		public uint DamagePerRound { get; set; }

		/// <summary>
		/// Chance to end this effect if the target has a unnatural toughness score. Null for no chance.
		/// </summary>
		public uint? UtbEndChance { get; set; }


	}
}
