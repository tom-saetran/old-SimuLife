using System;
using System.Collections.Generic;
using System.Linq;

namespace SimuLife {
	class Program {
		static void Main () {
			Population population = new Population(500);

			WriteTime();

			uint simulatorRuntime = 0;

			while (Simulator.TimeNow.Year < 2020) {
				simulatorRuntime++;
				Simulator.StartEvent(Simulator.Events.AdvanceTime);

				Simulant randomFemale = population.AliveFemale.ElementAt(Generators.Random.Next(population.AliveFemale.Count));
				Simulant randomMale = population.AliveMale.ElementAt(Generators.Random.Next(population.AliveMale.Count));

				Simulant resultingSimulant = Simulant.Conceive(randomFemale, randomMale);
				if (resultingSimulant != null) {
					if (resultingSimulant.Gender == Simulant.Genders.Female)
						population.AliveFemale.Add(resultingSimulant);
					else
						population.AliveMale.Add(resultingSimulant);
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
