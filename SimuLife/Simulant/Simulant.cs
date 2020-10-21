﻿using System.Collections.Generic;

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
		public Simulant		   ParentFemale		{ get; }
		public Simulant		   ParentMale		{ get; }
		public List<Simulant>  Children			{ get; protected set; }
		public Name			   Name				{ get; protected set; }
		public TimeCard		   TimeOfConception { get; }
		public TimeCard		   TimeOfBirth		{ get; }
		public TimeCard		   TimeOfDeath		{ get; protected set; }
		public Genders		   Gender			{ get; protected set; }
		public AlertnessStages AlertnessStage   { get; protected set; }
		public AwakenessStages AwakenessStage   { get; protected set; }

		public TimeCard AgeAtDeath => TimeCard.GetDifferenceInTimeCard(TimeOfDeath, TimeOfBirth);
		public TimeCard Age        => TimeCard.GetDifferenceInTimeCard(Simulator.TimeNow, TimeOfBirth);

		public Simulant (Simulant parentFemale, Simulant parentMale) {
			ParentFemale	 = parentFemale;
			ParentMale		 = parentMale;
			Children		 = new List<Simulant>(0);
			TimeOfConception = Simulator.TimeNow;
			TimeOfBirth		 = Generators.GenerateBirthTime(this);
			TimeOfDeath		 = Generators.GenerateDeathTime(this);
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
