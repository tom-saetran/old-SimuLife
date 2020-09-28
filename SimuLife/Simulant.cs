using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimuLife {

	class Name {

		public string FirstName { get; protected set; }
		public string LastName { get; protected set; }

		public Name (string firstName, string lastName) {
			FirstName = firstName;
			LastName = lastName;
		}
	}

	class Simulant {
		public enum Genders {
			Female,
			Male
		}
		public enum LifeStages {
			Concieved,		// [0-1>    Semester, Unborn
			Fetus,			// [1-3]    Semesters, Unborn
			Baby,			// [0-2>    Years
			Toddler,        // [2-6>    Years
			Child,          // [6-12>   Years
			Teen,           // [12-20>  Years
			YoungAdult,     // [20-32>  Years
			Adult,          // [32-46>  Years
			OldAdult,       // [46-62>  Years
			Senior,         // [62-80>  Years
			Elder,          // [80-100> Years
			Ancient         // [100>    Years
		}
		public enum HealthStages {
			Healthy,
			Recovering,
			Sick,
			VerySick,
			Dying,
			Dead
		}

		public Simulant ParentFemale { get; protected set; }
		public Simulant ParentMale { get; protected set; }
		public Name Name { get; protected set;}
		public Time ConceptionTime { get; protected set; }
		public Time BirthTime { get; protected set; }
		public Time DeathTime { get; protected set; }
		public Genders Gender { get; protected set; }
		public LifeStages LifeStage { get; protected set; }
		public HealthStages HealthStage { get; protected set; }

		public Simulant (Simulant parentFemale, Simulant parentMale) {
			ParentFemale = parentFemale;
			ParentMale = parentMale;
			Name = Generators.GenerateName(this);
			ConceptionTime = Simulator.TimeNow;
			BirthTime = Generators.GenerateBirthTime(this);
			DeathTime = Generators.GenerateDeathTime(this);
			Gender = Generators.GenerateGender();
			LifeStage = LifeStages.Concieved;
			HealthStage = HealthStages.Healthy;
		}
		public void Die () {
			HealthStage = HealthStages.Dead;
			DeathTime = Simulator.TimeNow;
		}
		public Simulant Conceive (Simulant partner) {

			float chance = 0.5f;	

			if (Gender == partner.Gender ||
				LifeStage > LifeStages.Teen ||
				partner.LifeStage > LifeStages.Teen ||
				LifeStage < LifeStages.OldAdult ||
				partner.LifeStage < LifeStages.OldAdult)
				return null;

			if (ParentFemale == partner.ParentFemale ||
				ParentMale == partner.ParentMale)
				chance = 0.2f;

			return Generators.Random.NextDouble() < chance ? (Gender == Genders.Female ? new Simulant(this, partner) : new Simulant(partner, this)) : null;
		}
	}
}
