using System.Collections.Generic;

// introduce waiting time for simulant close to each
// other to pass time waiting for information back called tidbits.

// tidbits are simulated tasks, it can be solo or via interaction
// they are tasks that consumes a given amount of time, and will
// eventually later in development interact with the simulants
// interests and abilities

// education is an example of mandatory tidbits throughout the simulants life
// from young age to diploma, or dropout, e.g elementary compulsory

namespace SimuLife {
	partial class Simulant {
		public Simulant		   ParentFemale		 { get; }
		public Simulant		   ParentMale		 { get; }
		public List<Simulant>  Children			 { get; protected set; }
		public Name			   Name				 { get; protected set; }
		public Genders		   Gender			 { get; protected set; }
		public AlertnessStages AlertnessStage    { get; protected set; }
		public AwakenessStages AwakenessStage    { get; protected set; }

		private uint TimeOfConception { get; }
		private uint TimeOfBirth      { get; }
		private uint TimeOfDeath      { get; set; }
		public TimeCard TimeCardOfConception =>	
			TimeCard.GetTimeCardFromTicks(TimeOfConception);
		public TimeCard TimeCardOfBirth =>
			TimeCard.GetTimeCardFromTicks(TimeOfBirth);
		public TimeCard TimeCardOfDeath =>
			TimeCard.GetTimeCardFromTicks(TimeOfDeath);
		public TimeCard SimulantAge	=>
			TimeCard.GetTimeCardFromTicks(Simulator.Time - TimeOfBirth);

		public Simulant (Simulant parentFemale, Simulant parentMale) {
			ParentFemale	 = parentFemale;
			ParentMale		 = parentMale;
			Children		 = new List<Simulant>(0);
			TimeOfConception = Simulator.Time;
			TimeOfBirth		 = Generators.GenerateBirthTime(TimeOfConception);
			TimeOfDeath		 = Generators.GenerateDeathTime(TimeOfConception);
			Gender			 = Generators.GenerateGender();
			Name			 = Generators.GenerateName(this);
			AlertnessStage	 = AlertnessStages.Comatose;
			AwakenessStage	 = AwakenessStages.Asleep;

			if (parentFemale != null)
				parentFemale.Children.Add(this);

			if (parentMale != null)
				parentMale.Children.Add(this);
		}
	}
}
