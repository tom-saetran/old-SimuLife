using System.Collections.Generic;
using System.Linq;

namespace SimuLife {
	class Population {
		public		Simulant  God		  { get; }
		public		Simulant  Jesus		  { get; }
		public		Simulant  Adam		  { get; }
		public		Simulant  Eve		  { get; }
		public List<Simulant> AliveFemale { get; }
		public List<Simulant> AliveMale   { get; }
		public List<Simulant> Dead		  { get; }

		public Population (int initialPopulationSize) {
			if (initialPopulationSize < 100)
				initialPopulationSize = 100;

			if (initialPopulationSize > 10000)
				initialPopulationSize = 10000;

			God			= new	   Simulant(null,  null,  this);
			Jesus		= new	   Simulant(God,   God,   this);
			Adam		= new	   Simulant(Jesus, Jesus, this);
			Eve			= new	   Simulant(Jesus, Jesus, this);
			AliveFemale = new List<Simulant>(initialPopulationSize * 100);
			AliveMale   = new List<Simulant>(initialPopulationSize * 100);
			Dead		= new List<Simulant>(initialPopulationSize * 1000);
			
			while (Adam.Gender == Simulant.Genders.Female)
				Adam = new Simulant(Jesus, Jesus, this);
			while (Eve.Gender == Simulant.Genders.Male)
				Eve = new Simulant(Jesus, Jesus, this);

			for (int i = 0; i < initialPopulationSize; i++) {
				Simulant initialSimulant = new Simulant(Eve, Adam, this);

				if (initialSimulant.Gender == Simulant.Genders.Female)
					AliveFemale.Add(initialSimulant);
				else
					AliveMale.Add(initialSimulant);
			}
		}
		public void AddSimulantToAlivePopulation (Simulant simulant) {
			if (simulant.Gender == Simulant.Genders.Female)
				AliveFemale.Add(simulant);
			else
				AliveMale.Add(simulant);
		}
		public void MoveSimulantToDeadPopulation (Simulant simulant) {
			_ = simulant.Gender == Simulant.Genders.Female ?
				AliveFemale.Remove(simulant) :
				AliveMale.Remove(simulant);
			Dead.Add(simulant);
		}
		public void MoveAllEligibleSimulantsToDeadPopulation () {
			List<Simulant> newlyDeadSimulants =
				AliveFemale.Where(sim =>
					sim.HealthStage == Simulant.HealthStages.Dead).Union(
						AliveMale.Where(sim =>
							sim.HealthStage == Simulant.HealthStages.Dead)).ToList();

			foreach (Simulant simulant in newlyDeadSimulants) {
				MoveSimulantToDeadPopulation(simulant);
				Simulant.AfterKill(simulant);
			}
		}
	}
}
