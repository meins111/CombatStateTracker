using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatStateTracker.Conditions
{
	interface IVarLengthCondition : ICondition
	{
		uint ChanceToEnd { get; set; }

		bool UtbDoublesChance { get; set; }

		bool Ongoing { get; set; }
	}
}
