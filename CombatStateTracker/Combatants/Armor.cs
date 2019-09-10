using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CombatStateTracker.Combatants
{
	public enum HitLocations { Head = 0, ArmLeft = 1, ArmRight = 2, Body = 3, LegLeft = 4, LegRight = 5 };

	public class Armor
	{
		public Dictionary<HitLocations, uint> Location2Armor {get; private set;}
		private uint? _all;
		public uint? All
		{ get
			{
				return _all;
			}
			set
			{
				_all = value;
				if (value != null)
				{
					Location2Armor[HitLocations.Head] = (uint)value;
					Location2Armor[HitLocations.ArmLeft] = (uint)value;
					Location2Armor[HitLocations.ArmRight] = (uint)value;
					Location2Armor[HitLocations.Body] = (uint)value;
					Location2Armor[HitLocations.LegLeft] = (uint)value;
					Location2Armor[HitLocations.LegRight] = (uint)value;
				}
			}
		}

		public Armor ()
		{
			All = null;
			Location2Armor = new Dictionary<HitLocations, uint>(6)
				{
					{ HitLocations.Head, 0},
					{ HitLocations.ArmLeft, 0},
					{ HitLocations.ArmRight, 0},
					{ HitLocations.Body, 0},
					{ HitLocations.LegLeft, 0},
					{ HitLocations.LegRight, 0},
				};
		}
	}
}