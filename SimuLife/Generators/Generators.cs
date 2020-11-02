using System;

namespace SimuLife {
	static partial class Generators {

		public  static readonly Random Random = new Random();
		private static readonly short simulantAgeMean = 77, simAgeStdDev = 9;

		public  static Simulant.Genders GenerateGender () => 
			Random.NextDouble() > 0.50888 ?
			   Simulant.Genders.Female:
			   Simulant.Genders.Male;
		private static string GetNewLastNameFromPool () {
			string[] pool = { "Arvidsen",
							  "Berge",
							  "Cakeboss",
							  "Didriksen",
							  "Elvisdatter",
							  "Fargeblyant",
							  "Gra",
							  "Haraldsen"};

			return pool[Random.Next(0, pool.Length)];
		}
		public  static Name   GenerateName (Simulant simulant) {
			string first = simulant.Gender == Simulant.Genders.Female ?
			FirstNamesFemale[Random.Next(FirstNamesFemale.Length)] :
			FirstNamesMale  [Random.Next(FirstNamesMale.Length)];

			if (simulant.ParentFemale == null || simulant.ParentMale == null) {
				return new Name(first, GetNewLastNameFromPool());
			}

			string last = Random.NextDouble() < 13 / 18 ?
			simulant.ParentMale.Name.LastName :
			simulant.ParentFemale.Name.LastName;

			last = Random.NextDouble() < 1 / 300 ?
			GetNewLastNameFromPool() : last;

			return new Name(first, last);
		}
		public  static uint   GenerateBirthTime (uint timeOfConception) =>
			timeOfConception + (uint) Random.Next(216, 288);
		public  static uint   GenerateDeathTime (uint timeOfConception) =>
			timeOfConception +
			(uint) Math.Abs(NormalDistribution(simulantAgeMean, simAgeStdDev)) *
			TimeCard.TicksInYear;
		public  static ushort GenerateIQLevel () => 
			(ushort) Math.Abs(NormalDistribution(105, 25));
		private static double NormalDistribution (short mean, short stdDev) => 
			mean + (stdDev *
			(Math.Sqrt(-2 * Math.Log(1 - Random.NextDouble())) *
			 Math.Sin(2 * Math.PI * (1 - Random.NextDouble()))));
	}
}
