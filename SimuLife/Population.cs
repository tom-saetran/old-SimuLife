using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace SimuLife {
	class Population {
		public		Simulant  God		{ get; protected set; }
		public		Simulant  Jesus		{ get; protected set; }
		public		Simulant  Adam		{ get; protected set; }
		public		Simulant  Eve		{ get; protected set; }
		public List<Simulant> Alive		{ get; protected set; }
		public List<Simulant> Dead		{ get; protected set; }

		public Population (int initialPopulationSize) {				
			God		  = new		 Simulant(null,  null);
			Jesus	  = new		 Simulant(God,   God);
			Adam	  = new		 Simulant(Jesus, Jesus);
			Eve		  = new		 Simulant(Jesus, Jesus);
			Alive	  = new List<Simulant>(initialPopulationSize);
			Dead	  = new List<Simulant>(initialPopulationSize);

			if (Adam.Gender == Simulant.Genders.Female)
				Simulant.ToggleGender(Adam);
			if (Eve.Gender == Simulant.Genders.Male)
				Simulant.ToggleGender(Eve);

			for (int i = 0; i < initialPopulationSize; i++) {
				Alive.Add(new Simulant(Eve, Adam));
			}
		}
	}
}
