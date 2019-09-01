using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatStateTracker.Combatants
{
	public class Combatant
	{
		public string Name { get; set; }
		public int Wounds { get; set; }
		public int WoundsMax {get; set;}
		public readonly Dictionary<HitLocations, uint> Location2Armor;
		public string Weapon { get; set; }
		public readonly IReadOnlyCollection<IConidtion> Conditions;

		public Combatant()
		{
			Location2Armor = new Dictionary<HitLocations, uint>()
			{
				{HitLocations.Head, 0 },
				{HitLocations.ArmLeft, 0 },
				{HitLocations.ArmRight, 0 },
				{HitLocations.Body, 0 },
				{HitLocations.LegLeft, 0 },
				{HitLocations.LegRight, 0 },
			};
			Conditions = new List<IConidtion>();
		}

		public void SetArmorPoints(HitLocations loc, uint ap)
		{
			Location2Armor[loc] = ap;
		}
		public void SetArmorPointsAll(uint ap)
		{
			foreach (var location in Location2Armor.Keys)
			{
				Location2Armor[location] = ap;
			}
		}

		public override string ToString()
		{
			var builder = new StringBuilder();
			builder.AppendLine($"Combatant: {Name}");
			builder.AppendLine($"\tWounds: {Wounds}/{WoundsMax}");
			if (Conditions.Count > 0)
			{
				builder.AppendLine($"\tConditions: {String.Join(",", Name)}");
			}
			return builder.ToString();
		}
	}
	
	public class Location2ArmorItem
	{
		public HitLocations loc;
		public uint ArmorPoints;
	}
}
