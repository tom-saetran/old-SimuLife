using System;

namespace SimuLife {
	class Program {
		static void Main () {
			Population TestSims = new Population(100);

			WriteTime();

			while (Simulator.TimeNow.Year < 2020) {
				Simulator.StartEvent(Simulator.Events.AdvanceTime);
				if (Simulator.TimeNow.Day == TimeCard.Days.Monday)
					continue;
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
