using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatStateTracker.Conditions
{
	public class GenericFixLenCondition : GenericCondition, IFixedLengthCondition
	{
		public GenericFixLenCondition()
			: base()
		{
			RoundsLeft = 0;
			MaxRounds = 0;
		}

		public GenericFixLenCondition(int duration)
			: base()
		{
			MaxRounds = duration;
			RoundsLeft = duration;
		}

		public int RoundsLeft { get; set; }
		public int MaxRounds { get; set; }

		public void ResetDuration()
		{
			RoundsLeft = MaxRounds;
		}
	}
}
