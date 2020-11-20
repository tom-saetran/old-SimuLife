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
		public List<Simulant>  Children			 { get; }
		public Name			   Name				 { get; }

		public Population MyPopulation  { get; }

		private uint   TimeOfConception { get; }
		private uint   TimeOfBirth      { get; }
		private uint   TimeOfDeath      { get; set; }
		private ushort AwakenessLevel   { get; set; }
		private ushort AlertnessLevel   { get; set; }
		private ushort EngagementLevel  { get; set; }
		private ushort IQLevel          { get; }

		public TimeCard TimeOfConceptionAsTimeCard =>	
			TimeCard.GetTimeCardFromTicks(TimeOfConception);
		public TimeCard TimeOfBirthAsTimeCard =>
			TimeCard.GetTimeCardFromTicks(TimeOfBirth);
		public TimeCard TimeOfDeathAsTimeCard =>
			TimeCard.GetTimeCardFromTicks(TimeOfDeath);
		public TimeCard CurrentAgeAsTimeCard =>
			TimeCard.GetTimeCardFromTicks(Simulator.Time - TimeOfBirth);
		public TimeCard AgeAtDeathAsTimeCard =>
			TimeCard.GetTimeCardFromTicks(TimeOfDeath - TimeOfConception);

		public Simulant (Simulant parentFemale, Simulant parentMale, Population population) {
			MyPopulation     = population;
			ParentFemale	 = parentFemale;
			ParentMale		 = parentMale;
			Children		 = new List<Simulant>(0);
			TimeOfConception = Simulator.Time;
			TimeOfBirth		 = Generators.GenerateBirthTime(TimeOfConception);
			TimeOfDeath		 = Generators.GenerateDeathTime(TimeOfConception);
			Gender			 = Generators.GenerateGender();
			Name			 = Generators.GenerateName(this);
			AlertnessLevel	 = 33;
			AwakenessLevel	 = 33;
			EngagementLevel  = 33;
			IQLevel			 = Generators.GenerateIQLevel();

			if (parentFemale != null)
				parentFemale.Children.Add(this);

			if (parentMale != null)
				parentMale.Children.Add(this);
		}
	}
}
