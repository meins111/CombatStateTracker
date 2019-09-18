using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombatStateTracker;


namespace CombatTrackerCLI
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(">>> Warhammer 40k: Combat State tracker <<<");
			while (true)
			{
				Console.WriteLine(">>> Main Menu: Select one of the following options: <<<");
				Console.WriteLine("\t> New Combat: [n|N|New]");
				Console.WriteLine("\t> Load combat state from file: [l|L|Load]");
				Console.WriteLine("\t> Exit: [e|E|Exit]");
				string choice = Console.ReadLine();
				switch (choice)
				{
					// Load a previously created combat state object
					case "L": case "l":
					case "Load":
						var obj = LoadFromXml(CombatStateTracker.CombatStateSerializer.DeserializeFromXml);
						if (obj == null)
						{
							Console.WriteLine(">> Failed to parse object from pointed file.");
							continue;
						}
						CombatStateCliMenu.Run(obj as CombatState);
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

		public delegate object ParseObjectFromFile(string path);

		public static object LoadFromXml(ParseObjectFromFile func)
		{
			Console.WriteLine("> Enter path to a XML file to load from:");
			string path = Console.ReadLine();
			if (!File.Exists(path))
			{
				return null;
			}
			if (Path.GetExtension(path) == ".xml")
			{
				return func(path);
			}

			return null;

		}


		private static void TestSerialization()
		{
			var state = new CombatState("TestCombat", 1);
			state.Combatants.Add(new CombatStateTracker.Combatants.Combatant() { Name = "Ork", Wounds = 12, WoundsMax = 12 });
			state.Combatants.Add(new CombatStateTracker.Combatants.Combatant() { Name = "Guardsman", Wounds = 7, WoundsMax = 7 });
			Console.WriteLine($"Serializing state: \n{state.ToString()}");
			CombatStateSerializer.SerializeToXml(state);
			Console.WriteLine("Success!");
			string fileName = "TestCombat_1.xml";
			Console.WriteLine($"Deserializing {fileName}...");
			var stateReload = CombatStateSerializer.DeserializeFromXml(fileName);
			Console.WriteLine($"Success! Deserialized State: \n{stateReload.ToString()}.");
		}
	}
}
