namespace SimuLife {
	partial class Simulant {
		public Simulant			ParentFemale	{ get; protected set; }
		public Simulant			ParentMale		{ get; protected set; }
		public Simulant[]		Children		{ get; protected set; }
		public Name				Name			{ get; protected set; }
		public TimeCard			ConceptionTime	{ get; protected set; }
		public TimeCard			BirthTime		{ get; protected set; }
		public TimeCard			DeathTime		{ get; protected set; }
		public Genders			Gender			{ get; protected set; }
		public LifeStages		LifeStage		{ get; protected set; }
		public HealthStages		HealthStage		{ get; protected set; }
		public AlertnessStages	AlertnessStage  { get; protected set; }
		public AwakenessStages  AwakenessStage  { get; protected set; }

		public Simulant (Simulant parentFemale, Simulant parentMale) {
			ParentFemale   = parentFemale;
			ParentMale     = parentMale;
			Children	   = new Simulant[0];
			ConceptionTime = Simulator.TimeNow;
			BirthTime	   = Generators.GenerateBirthTime(this);
			DeathTime	   = Generators.GenerateDeathTime(this);
			Gender		   = Generators.GenerateGender();
			Name           = Generators.GenerateName(this);
			LifeStage	   = LifeStages.Concieved;
			HealthStage    = HealthStages.Healthy;
			AlertnessStage = AlertnessStages.Comatose;
			AwakenessStage = AwakenessStages.Asleep;
		}
	}
}
