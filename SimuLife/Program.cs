using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace SimuLife {
	class Program {
		static void Main () {
			Population population = new Population(50);

			WriteTime();

			uint simulatorRuntime = 0;

			while (Simulator.TimeNow.Year < 2020) {
				simulatorRuntime++;
				Simulator.StartEvent(Simulator.Events.AdvanceTime);

				Simulant one = population.AliveFemale.ElementAt(Generators.Random.Next(population.AliveFemale.Count));
				Simulant two = population.AliveMale.ElementAt(Generators.Random.Next(population.AliveMale.Count));

				Simulant newSim = Simulant.Conceive(one, two);
				if (newSim != null) {
					if (newSim.Gender == Simulant.Genders.Female)
					population.AliveFemale.Add(newSim);
				else
					population.AliveMale.Add(newSim);
				}

				if (TimeCard.GetTicksFromTimeCard(Simulator.TimeNow) % 336 == 0) {
					List<Simulant> newlyDeadSimulants =
						population.AliveFemale.Where(sim =>
							sim.HealthStage == Simulant.HealthStages.Dead).Union(
								population.AliveMale.Where(sim =>
									sim.HealthStage == Simulant.HealthStages.Dead)).ToList();

					foreach (Simulant simulant in newlyDeadSimulants) {
						_ = simulant.Gender == Simulant.Genders.Female ?
							population.AliveFemale.Remove(simulant) :
							population.AliveMale.Remove(simulant);
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
