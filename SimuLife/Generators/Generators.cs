using System;

namespace SimuLife {
	static partial class Generators {

		public static readonly Random Random = new Random();

		public static Simulant.Genders GenerateGender () {
			return Random.NextDouble() < 0.5 ?
				   Simulant.Genders.Female   :
			       Simulant.Genders.Male;
		}

		public static string GetNewLastNameFromPool () {
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

		public static Name GenerateName (Simulant simulant) {
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

		public static TimeCard GenerateBirthTime (Simulant simulant) {
			return TimeCard.GetTimeCardFromTicks(
				   TimeCard.GetTicksFromTimeCard(simulant.TimeOfConception) +
				   (uint) Random.Next(216, 288)); // 3 seasons +/- 3 days
		}

		public static TimeCard GenerateDeathTime (Simulant simulant) {
			return TimeCard.GetTimeCardFromTicks(
				   TimeCard.GetTicksFromTimeCard(simulant.TimeOfConception) +
				   (uint)
					 (77 +  // mean
					   (9 * // stdDev
					     (Math.Sqrt
					       (-2 * Math.Log
						     (1 - Random.NextDouble())) *
				  	      Math.Sin
					       (2 * Math.PI * 
					         (1 - Random.NextDouble()))))) *
							   336); // one year
		}
	}
}
