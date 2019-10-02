using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatStateTracker.Conditions
{
	public interface ICondition
	{
		string Name { get; set; }
		string Description { get; set; }

		string Print();
	}
}
