using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatStateTracker.Conditions
{
	public interface IFixedLengthCondition : ICondition
	{
		int RoundsLeft { get; set; }
		int MaxRounds { get; set; }
		void ResetDuration();
	}
}
