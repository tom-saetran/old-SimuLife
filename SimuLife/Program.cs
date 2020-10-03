using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SimuLife {
	class Program {
		static void Main(string[] args) {
			Simulant God = new Simulant(null, null);
			List<Simulant> Simulants = new List<Simulant>();

			for (int i = 0; i < 5000000; i++) {
				Simulants.Add(new Simulant(God, God));
				Simulator.StartEvent(Simulator.Events.AdvanceTime);
			}
			Environment.Exit(420);
		}
	}
}
