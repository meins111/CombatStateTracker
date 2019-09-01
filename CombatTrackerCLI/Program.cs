using System;
using System.Collections.Generic;
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
			var state = new CombatState("TestCombat", 1);
			state.Combatants.Add(new CombatStateTracker.Combatants.Combatant() { Name="Ork", Wounds=12, WoundsMax=12});
			Console.WriteLine($"Serializing state: \n{state.ToString()}");
			CombatStateSerializer.SerializeToXml(state);
			Console.WriteLine("Success!");
			string fileName = "CombatState_TestCombat_1.xml";
			Console.WriteLine($"Deserializing {fileName}...");
			var stateReload = CombatStateSerializer.DeserializeFromXml(fileName);
			Console.WriteLine($"Success! Deserialized State: \n{stateReload.ToString()}.");
			Console.ReadLine();
		}
	}
}
