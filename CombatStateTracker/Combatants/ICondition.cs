﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatStateTracker.Combatants
{
	public interface ICondition
	{
		string Name { get; set; }
		int RoundsLeft { get; set; }
	}
}