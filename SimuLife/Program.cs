using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SimuLife {
	class Program {
		static void Main () {
			Population population = new Population(100);

			WriteTime();

			while (Simulator.TimeNow.Year < 2020) {
				Simulator.StartEvent(Simulator.Events.AdvanceTime);
				Simulant one = population.Alive[Generators.Random.Next(population.Alive.Count)];
				Simulant two = population.Alive[Generators.Random.Next(population.Alive.Count)];

				Simulant x = Simulant.Conceive(one, two);
				if (x != null) {
					population.Alive.Add(x);
				}

				if (Simulator.TimeNow.Ticks % 336 == 0) {
					List<Simulant> moveToDead = new List<Simulant>(0);

					foreach (Simulant simulant in population.Alive) {
						if (simulant.HealthStage == Simulant.HealthStages.Dead) {
							moveToDead.Add(simulant);
						}
					}
					foreach (Simulant simulant in moveToDead) {
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
