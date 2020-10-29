using System;
using System.Collections.Generic;
using System.Linq;

namespace SimuLife {
	class Program {
		static void Main () {
			Population population = new Population(500);

			WriteTime();

			while (Simulator.Time < 2020 * TimeCard.TicksInYear) {
				Simulator.StartEvent(Simulator.YearlyEvents.AdvanceTime);

				Simulant randomFemale = population.AliveFemale.ElementAt(Generators.Random.Next(population.AliveFemale.Count));
				Simulant randomMale   = population.AliveMale.ElementAt(Generators.Random.Next(population.AliveMale.Count));

				Simulant resultingSimulant = Simulant.Conceive(randomFemale, randomMale);
				if (resultingSimulant != null) {
					population.AddSimulantToAlivePopulation(resultingSimulant);
				}
				//WriteTime();
				if (Simulator.Time % TimeCard.TicksInYear == 0) {
					population.MoveAllEligibleSimulantsToDeadPopulation();
				}
			}
			List<Simulant> deadFemales = population.Dead.Where(sim => sim.Gender == Simulant.Genders.Female).ToList();
			List<Simulant> deadMales   = population.Dead.Where(sim => sim.Gender == Simulant.Genders.Male).ToList();

			WriteTime();
			Environment.Exit(420);
		}

		public static void WriteTime () {
			Console.WriteLine(
				"Time is " + Simulator.TimeNow.Hour   + 
					  ", " + Simulator.TimeNow.Day    + 
					  ", " + Simulator.TimeNow.Season + 
					  ", " + Simulator.TimeNow.Year);
		}
	}
}
