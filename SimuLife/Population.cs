﻿namespace SimuLife {
	class Population {
		protected Simulant   God, Jesus, Adam, Eve;
		public    Simulant[] ChildrenOfAdamAndEve { get; protected set; }
		public    Simulant[] Simulants			  { get; protected set; }

		public Population (int initialPopulationSize) {				
			God   = new Simulant(null,  null);
			Jesus = new Simulant(God,   God);
			Adam  = new Simulant(Jesus, Jesus);
			Eve   = new Simulant(Jesus, Jesus);		
			ChildrenOfAdamAndEve = new Simulant[initialPopulationSize];

			if (Adam.Gender == Simulant.Genders.Female)
				Simulant.ToggleGender(Adam);
			if (Eve.Gender == Simulant.Genders.Male)
				Simulant.ToggleGender(Eve);

			for (int i = 0; i < initialPopulationSize; i++) {
				ChildrenOfAdamAndEve[i] = new Simulant(Eve, Adam);
			}
		}
	}
}
