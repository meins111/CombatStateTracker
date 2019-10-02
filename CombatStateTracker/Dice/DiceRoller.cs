using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatStateTracker.Dice
{
	public static class DiceRoller
	{
		static DiceRoller()
		{
			Rnd = new Random();
		}

		private static Random Rnd;

		/// <summary>
		/// Percentile roll, comparing the result against a target number.
		/// </summary>
		/// <param name="targetNumber">Target number to meet or roll under.</param>
		/// <returns>True if the roll is below or equal the target number.</returns>
		public static bool Roll100Check(uint targetNumber)
		{
			var roll = Rnd.Next(1, 101);
			if (targetNumber < roll) return false;
			else return true;
		}



	}
}
