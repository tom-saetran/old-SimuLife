using System;
using System.Collections.Generic;
using System.Linq;

namespace SimuLife {
	class Program {
		static void Main () {
			Population population = new Population(50);

			WriteTime();

			uint simulatorRuntime = 0;

			while (Simulator.TimeNow.Year < 2020) {
				simulatorRuntime++;
				Simulator.StartEvent(Simulator.Events.AdvanceTime);

				Simulant one = population.Alive.ElementAt(Generators.Random.Next(population.Alive.Count));
				Simulant two = population.Alive.ElementAt(Generators.Random.Next(population.Alive.Count));

				Simulant newSim = Simulant.Conceive(one, two);
				if (newSim != null) {
					population.Alive.Add(newSim);
				}

				if (TimeCard.GetTicksFromTimeCard(Simulator.TimeNow) % 336 == 0) {

					List<Simulant> newlyDeadSimulants =
						population.Alive.Where(sim =>
							sim.HealthStage == Simulant.HealthStages.Dead).ToList();

					foreach (Simulant simulant in newlyDeadSimulants) {	
						population.Alive.Remove(simulant);
						population.Dead.Add(simulant);
					}					
				}
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
