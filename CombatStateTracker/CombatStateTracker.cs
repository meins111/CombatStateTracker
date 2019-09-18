using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombatStateTracker.Combatants;

namespace CombatStateTracker
{
	public class CombatStateTracker
	{
		public CombatState State { get; private set; }

		public CombatStateTracker (CombatState state)
		{
			State = state;
		}

		public CombatStateTracker (string path)
		{
			State = CombatStateSerializer.DeserializeFromXml(path);
		}

		public void MoveNextRound()
		{
			State.CurrentRound++;
			foreach (var combatant in State.Combatants)
			{
				foreach (var cond in combatant.Conditions)
				{
					if (cond.RoundsLeft == 0)
					{
						combatant.Conditions.Remove(cond);
						continue;
					}
					switch (cond)
					{
						case IDamageOverTime dot:
							// Check whether UTB can end the effect - if so roll a check against the EndChance
							if (dot.UtbEndChance.HasValue && combatant.UTB.HasValue 
								&& Dice.DiceRoller.Roll100Check((uint)dot.UtbEndChance))
							{
								// 
								cond.RoundsLeft = 0;
								continue;
							}
							combatant.Wounds -= (int)dot.DamagePerRound;
							break;

						default: break;
					}
					// Countdown duration counter
					cond.RoundsLeft -= 1;
				}
			}
		}
	}
}
