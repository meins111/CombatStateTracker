using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombatStateTracker;

namespace CombatTrackerCLI
{
	internal static class CombatantCliMenu
	{
		public static void CombatantDialog(CombatStateTracker.Combatants.Combatant combatant)
		{
			Console.WriteLine("\n>>> Combatant Menu: Select one of the following options: <<<");
			Console.WriteLine("\t> ");

			// TODO: Implement change dialogue
			Console.WriteLine("NYI");
		}

		public static CombatStateTracker.Combatants.Combatant NewCombatantDialog()
		{
			var combatant = new CombatStateTracker.Combatants.Combatant();
			Console.WriteLine("\t\t> Name of Combatant: ");
			combatant.Name = Console.ReadLine();
			Console.WriteLine("\t\t> Max. Wounds: ");
			int tmp;
			while (!int.TryParse(Console.ReadLine(), out tmp))
			{
				Console.WriteLine("Invalid Input. Try again.");
				// TODO: add a cancelation option. Maybe.
			}
			combatant.WoundsMax = tmp;

			Console.WriteLine("\t\t> Current Wounds: ");
			while (!int.TryParse(Console.ReadLine(), out tmp))
			{
				Console.WriteLine("Invalid Input. Try again.");
				// TODO: add a cancelation option. Maybe.
			}
			combatant.Wounds = tmp;

			Console.WriteLine("\t\t> Parry Rating: ");
			uint uTmp;
			while (!uint.TryParse(Console.ReadLine(), out uTmp))
			{
				Console.WriteLine("Invalid Input. Try again.");
				// TODO: add a cancelation option. Maybe.
			}
			combatant.Parry = uTmp;

			Console.WriteLine("\t\t> Dodge Rating: ");
			while (!uint.TryParse(Console.ReadLine(), out uTmp))
			{
				Console.WriteLine("Invalid Input. Try again.");
				// TODO: add a cancelation option. Maybe.
			}
			combatant.Dodge = uTmp;

			// TODO: add Armor & Condition dialogue call as well.

			return combatant;
		}
	}
}
