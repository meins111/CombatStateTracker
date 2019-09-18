using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CombatStateTracker.Combatants
{
	public class Combatant
	{
		public string Name { get; set; }
		public int Wounds { get; set; }
		public uint Dodge { get; set; }
		public uint Parry { get; set; }
		public int WoundsMax {get; set;}
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
		}

		public override string ToString()
		{
			var builder = new StringBuilder();
			builder.AppendLine($"Combatant: {Name}");
			builder.AppendLine($"\tWounds: {Wounds}/{WoundsMax}");
			builder.AppendLine($"\tDodge: {Dodge}\tParry: {Parry}");
			builder.AppendLine("\tArmor:");
			builder.AppendLine($"\t\t{Armor.Location2Armor[HitLocations.Head]}");
			builder.AppendLine($"\t{Armor.Location2Armor[HitLocations.ArmLeft]}\t\t{Armor.Location2Armor[HitLocations.ArmRight]}");
			builder.AppendLine($"\t\t{Armor.Location2Armor[HitLocations.Body]}");
			builder.AppendLine($"\t{Armor.Location2Armor[HitLocations.LegLeft]}\t\t{Armor.Location2Armor[HitLocations.LegRight]}");
			if (Conditions.Count > 0)
			{
				builder.AppendLine($"\tConditions: {String.Join(",", Name)}");
			}
			return builder.ToString();
		}
	}
}
