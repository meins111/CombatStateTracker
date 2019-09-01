using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using CombatStateTracker.Combatants;

namespace CombatStateTracker
{
	public class CombatState
	{
		public uint CurrentRound { get; set; }
		public string Name { get; set; }
		public List<Combatant> Combatants;

		public CombatState()
		{
			Combatants = new List<Combatant>();
		}


		public CombatState(string name, uint currentRound) 
		{
			Combatants = new List<Combatant>();
			CurrentRound = currentRound;
			Name = name;
		}

		public override string ToString()
		{
			var s = new StringBuilder();
			s.AppendLine($"Combat Round:");
			s.AppendLine($"\tName: {Name}");
			s.AppendLine($"\tCurrent Round: {CurrentRound}");
			if (Combatants.Count > 0)
			{
				s.AppendLine($"\n\tCombatants: {String.Join("\n\t", Combatants)}");
			}
			return s.ToString();
		}

	}

	#region Serialization
	public static class CombatStateSerializer
	{
		private const string mNamePrefix = "CombatState_";
		public static void SerializeToXml(CombatState state)
		{
			// XML Serializer for the object
			var serializer = new XmlSerializer(state.GetType());

			// XML Writer 
			var writer = XmlWriter.Create(state.Name + "_" + state.CurrentRound + ".xml");

			// Write the file
			serializer.Serialize(writer, state);
		}

		public static CombatState DeserializeFromXml(string fileName)
		{
			// XML Serializer for the object
			var serializer = new XmlSerializer(typeof(CombatState));

			// XML Reader
			var reader = new XmlTextReader(fileName);

			// Deserialize
			return serializer.Deserialize(reader) as CombatState;
		}
	}
	#endregion
}
