using System.Collections.Generic;

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
			God			= new	   Simulant(null,  null);
			Jesus		= new	   Simulant(God,   God);
			Adam		= new	   Simulant(Jesus, Jesus);
			Eve			= new	   Simulant(Jesus, Jesus);
			AliveFemale = new List<Simulant>(initialPopulationSize * 100);
			AliveMale   = new List<Simulant>(initialPopulationSize * 100);
			Dead		= new List<Simulant>(initialPopulationSize * 1000);
			
			if (Adam.Gender == Simulant.Genders.Female)
				Adam = new Simulant(Jesus, Jesus);
			if (Eve.Gender == Simulant.Genders.Male)
				Eve = new Simulant(Jesus, Jesus);

			for (int i = 0; i < initialPopulationSize; i++) {
				Simulant initialSimulant = new Simulant(Eve, Adam);

				if (initialSimulant.Gender == Simulant.Genders.Female)
					AliveFemale.Add(initialSimulant);
				else
					AliveMale.Add(initialSimulant);
			}
		}
	}
}
