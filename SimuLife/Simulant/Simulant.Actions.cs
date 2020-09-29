using System;
using System.Collections.Generic;
using System.Text;

namespace SimuLife {
	partial class Simulant {
		public static void Kill (Simulant simulant) {
			simulant.HealthStage = HealthStages.Dead;
			simulant.DeathTime = Simulator.TimeNow;
		}

		public static Simulant Conceive (Simulant simulant, Simulant partner) {

			float chance = 0.82f;

			if (simulant.Gender == partner.Gender ||
				simulant.LifeStage > LifeStages.Teen ||
				partner.LifeStage > LifeStages.Teen ||
				simulant.LifeStage < LifeStages.OldAdult ||
				partner.LifeStage < LifeStages.OldAdult)
				return null;

			if (simulant.ParentFemale == partner.ParentFemale ||
				simulant.ParentMale == partner.ParentMale)
				chance = 0.13f;

			if (simulant.ParentFemale == partner.ParentFemale &&
				simulant.ParentMale == partner.ParentMale)
				chance = 0.02f;

			return Generators.Random.NextDouble() < chance ? (simulant.Gender == Genders.Female ? new Simulant(simulant, partner) : new Simulant(partner, simulant)) : null;
		}
	}
}
