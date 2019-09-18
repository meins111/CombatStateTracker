using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatTrackerCLI
{
	public static class CombatStateCliMenu
	{
		public static void Run(CombatStateTracker.CombatState state)
		{
			while (true)
			{
				Console.WriteLine("\n>>> Combat State Tracker Menu: Select one of the following options: <<<");
				Console.WriteLine("\t> New Combatatant: [n|N|New]");
				Console.WriteLine("\t> Show Status: [s|S|Status]");
				Console.WriteLine("\t> List Combatants: [l|ls|L|List");
				Console.WriteLine("\t> Select Combatant: [c|C|Combatant]");
				Console.WriteLine("\t> Advance to next round: [a|A|Advance]");
				Console.WriteLine("\t> Exit: [e|E|Exit]");
				string choice = Console.ReadLine();
				switch (choice)
				{
					// Load a previously created combat state object
					case "n":
					case "N":
					case "New":
						state.Combatants.Add(CombatantCliMenu.NewCombatantDialog());
						break;

					case "s":
					case "S":
					case "Status":
						Console.WriteLine(state.ToString());
						break;

					case "l":
					case "L":
					case "ls":
					case "List":
						uint i = 0;
						foreach (var com in state.Combatants)
						{
							Console.WriteLine($"\t\t\t> {i}: {com.Name}");
							i++;
						}
						break;

					case "c":
					case "C":
					case "Combatant":
						Console.WriteLine("\t\t> Enter index of combatant to select (tip: use the List option to get this ID): ");
						int tmp;
						while (!int.TryParse(Console.ReadLine(), out tmp) || tmp > state.Combatants.Count || tmp < 0)
						{
							Console.WriteLine("\t\t\t> Invalid input. Try again.");
						}
						CombatantCliMenu.CombatantDialog(state.Combatants[tmp]);
						break;

					case "a":
					case "A":
					case "Advance":
						var stateTracker = new CombatStateTracker.CombatStateTracker(state);
						stateTracker.MoveNextRound();
						Console.WriteLine("Done.");
						break;

					case "E":
					case "e":
					case "Exit":
						Console.WriteLine("The Emperor protects!");
						return;
					default:
						continue;
				}
			}
		}
	}
}
