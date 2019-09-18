using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ExtendedXmlSerializer;
using CombatStateTracker.Combatants;
using ExtendedXmlSerializer.Configuration;
using ExtendedXmlSerializer.ExtensionModel.Xml;

namespace CombatStateTracker
{
	public class CombatState
	{
		public uint CurrentRound { get; set; }
		public string Name { get; set; }
		public List<Combatant> Combatants { get; set; }

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
			// Setup extend serializer
			var serializer = new ConfigurationContainer()
					.EnableImplicitTypingFromNested<CombatState>()
					.Create();

			// XML Writer 
			var writer = XmlWriter.Create(state.Name + "_" + state.CurrentRound + ".xml");

			// Serialize
			serializer.Serialize(writer, state);

			// Finalize
			writer.Flush();
			writer.Dispose();
		}

		public static CombatState DeserializeFromXml(string fileName)
		{
			// XML Serializer for the object
			var serializer = new ConfigurationContainer()
					.EnableImplicitTypingFromNested<CombatState>()
					.Create();

			// XML Reader
			using (var reader = new XmlTextReader(fileName))
			{
				// Deserialize
				return serializer.Deserialize(reader) as CombatState;
			}
		}
	}
	#endregion
}
