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
				if (resultingSimulant != null)
					population.AddSimulantToAlivePopulation(resultingSimulant);

				if (Simulator.Time % TimeCard.TicksInYear == 0)
					population.MoveAllEligibleSimulantsToDeadPopulation();
			}
			List<Simulant> deadFemales = population.Dead.Where(sim => sim.Gender == Simulant.Genders.Female).ToList();
			List<Simulant> deadMales   = population.Dead.Where(sim => sim.Gender == Simulant.Genders.Male).ToList();

			List<Simulant> Omnipotent       = population.Dead.Where(sim => sim.IQ == Simulant.IQs.Omnipotent).ToList();
			List<Simulant> Savant           = population.Dead.Where(sim => sim.IQ == Simulant.IQs.Savant).ToList();
			List<Simulant> Genious          = population.Dead.Where(sim => sim.IQ == Simulant.IQs.Genious).ToList();
			List<Simulant> VeryHigh         = population.Dead.Where(sim => sim.IQ == Simulant.IQs.VeryHigh).ToList();
			List<Simulant> High             = population.Dead.Where(sim => sim.IQ == Simulant.IQs.High).ToList();
			List<Simulant> Normal           = population.Dead.Where(sim => sim.IQ == Simulant.IQs.Normal).ToList();
			List<Simulant> SlightlyRetarded = population.Dead.Where(sim => sim.IQ == Simulant.IQs.SlightlyRetarded).ToList();
			List<Simulant> Retarded         = population.Dead.Where(sim => sim.IQ == Simulant.IQs.Retarded).ToList();
			List<Simulant> SeverelyRetarded = population.Dead.Where(sim => sim.IQ == Simulant.IQs.SeverelyRetarded).ToList();



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
