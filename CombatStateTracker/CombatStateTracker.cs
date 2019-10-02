using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombatStateTracker.Combatants;
using CombatStateTracker.Conditions;

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
					EndOfRoundCondition(cond, combatant);
					if (!IsOngoing(cond))
					{
						combatant.Conditions.Remove(cond);
					}
				}
			}
		}

		private void EndOfRoundCondition(ICondition condition, Combatant comb)
		{
			if (condition is IFixedLengthCondition)
			{
				var fix = condition as IFixedLengthCondition;
				fix.RoundsLeft--;
				if (fix.RoundsLeft <= 0) return;
			}

			if (condition is IVarLengthCondition)
			{
				var varLen = condition as IVarLengthCondition;
				if (!varLen.Ongoing) return;
				var chance2End = varLen.ChanceToEnd;
				if (varLen.UtbDoublesChance && comb.UTB != null && comb.UTB > 0) chance2End *= 2;
				if (Dice.DiceRoller.Roll100Check(chance2End))
				{
					varLen.Ongoing = false;
					return;
				}
			}

			if (condition is IDamage)
			{
				var dam = condition as IDamage;
				if (dam.IgnoresArmor && dam.IgnoresToughness)
				{
					comb.Wounds -= (int)dam.Damage;
				}
				else if (dam.IgnoresArmor)
				{
					int damAfterSoak = (int)dam.Damage - (int)comb.TTB;
					if (damAfterSoak > 0)
					{
						comb.Wounds -= damAfterSoak;
					}
				}
				else if (dam.IgnoresToughness)
				{
					int damAfterSoak = (int)dam.Damage - (int)comb.Armor.Location2Armor[dam.Location];
					if (damAfterSoak > 0)
					{
						comb.Wounds -= damAfterSoak;
					}
				}
				else
				{
					int damAfterSoak = (int)dam.Damage - (int)comb.Armor.Location2Armor[dam.Location];
					damAfterSoak -= (int)comb.TTB;
					if (damAfterSoak > 0)
					{
						comb.Wounds -= damAfterSoak;
					}
				}
			}
		}

		private bool IsOngoing(ICondition condition)
		{
			switch (condition)
			{
				case IVarLengthCondition varLen:
					return varLen.Ongoing;

				case IFixedLengthCondition fixLen:
					if (fixLen.RoundsLeft > 0) return true;
					else return false;

				default:
					return true;
			}
		}
	}
}
