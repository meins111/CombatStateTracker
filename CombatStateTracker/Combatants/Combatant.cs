using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CombatStateTracker.Conditions;

namespace CombatStateTracker.Combatants
{
	public class Combatant
	{
		public string Name { get; set; }
		public int Wounds { get; set; }
		public uint Dodge { get; set; }
		public uint Parry { get; set; }
		public int WoundsMax {get; set;}
		public uint TTB { get; set; }
		public Armor Armor { get; set; }
		public uint? UTB { get; set; }
		public string Weapon { get; set; }
		public readonly List<ICondition> Conditions;

		public Combatant()
		{
			Conditions = new List<ICondition>();
			Armor = new Armor();
			Wounds = 0;
			WoundsMax = 0;
			Dodge = 0;
			Parry = 0;
			UTB = null;
			TTB = 0;
		}

		public string ToString(bool printArmor = false, bool printConditions = true)
		{
			var builder = new StringBuilder();
			builder.AppendLine($"Combatant: {Name}");
			builder.AppendLine($"\tWounds: {Wounds}/{WoundsMax}");
			builder.AppendLine($"\tDodge: {Dodge}\tParry: {Parry}");
			if (printArmor) Armor.ToString();
			if (printConditions && Conditions.Count>0) builder.AppendLine($"Conditions: {String.Join(", ", Conditions.Select(x => x.Print()))}");
			return builder.ToString();
		}
	}
}
