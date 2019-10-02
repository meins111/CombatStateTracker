using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatStateTracker.Conditions
{
	public class GenericCondition : ICondition
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public GenericCondition()
		{
			Name = "Generic Condition";
			Description = "Info text for the condition";
		}

		public string Print()
		{
			return $"{Name} ({Description})";
		}
	}
}
