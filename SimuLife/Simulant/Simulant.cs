namespace SimuLife {
	partial class Simulant {
		public Simulant		ParentFemale	{ get; protected set; }
		public Simulant		ParentMale		{ get; protected set; }

		public Name			Name			{ get; protected set; }

		public Time			ConceptionTime	{ get; protected set; }
		public Time			BirthTime		{ get; protected set; }
		public Time			DeathTime		{ get; protected set; }

		public Genders		Gender			{ get; protected set; }
		public LifeStages	LifeStage		{ get; protected set; }
		public HealthStages HealthStage		{ get; protected set; }

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
		public void Die () {
			HealthStage = HealthStages.Dead;
			DeathTime = Simulator.TimeNow;
		}
	}
}
