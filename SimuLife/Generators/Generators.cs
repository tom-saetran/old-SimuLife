using System;

namespace SimuLife {
	static partial class Generators {

		public static readonly Random Random = new Random();

		public static Simulant.Genders GenerateGender () {
			return Random.NextDouble() < 0.5 ?
				   Simulant.Genders.Female   :
			       Simulant.Genders.Male;
		}
		public static Name GenerateName (Simulant simulant) {
			string first;

			first = simulant.Gender == Simulant.Genders.Female     ?
			FirstNamesFemale[Random.Next(FirstNamesFemale.Length)] :
			FirstNamesMale  [Random.Next(FirstNamesMale.Length)];

			return new Name(first, "Last");
		}

		public static TimeCard GenerateBirthTime (Simulant simulant) {
			return TimeCard.SetFromRawTime(
				   TimeCard.GetRawFromTime(simulant.ConceptionTime) +
				   (uint) Random.Next(18, 25));
		}
		public static TimeCard GenerateDeathTime (Simulant simulant) {
			return TimeCard.SetFromRawTime(
				   TimeCard.GetRawFromTime(simulant.ConceptionTime) +
				   (uint)
					(75 +  // mean
					  (25 * // stdDev
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
