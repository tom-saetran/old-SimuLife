using System;

namespace SimuLife {
	class Program {
		static void Main () {
			Population population = new Population(50);
			WriteTime();
			for (int i = 0; i < population.Simulants.Length; i++) {
				Simulator.StartEvent(Simulator.Events.AdvanceTime);
			}
			WriteTime();
			Environment.Exit(420);
		}

		static void WriteTime () {
			Console.WriteLine(
				"Time is " + Simulator.TimeNow.Hour   + 
					  ", " + Simulator.TimeNow.Day    + 
					  ", " + Simulator.TimeNow.Season + 
					  ", " + Simulator.TimeNow.Year);
		}
	}
}
