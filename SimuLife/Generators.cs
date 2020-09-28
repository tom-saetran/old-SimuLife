using System;

namespace SimuLife {
	static class Generators {

		public static readonly Random Random = new Random();

		public static Simulant.Genders GenerateGender () {
			return Random.NextDouble() < 0.5 ?
			Simulant.Genders.Female:
			Simulant.Genders.Male;
		}
		public static Name GenerateName (Simulant simulant) {
			return new Name("First", "Last");
		}
		public static Time GenerateBirthTime (Simulant simulant) {
			// time now + ~3 seasons
			return new Time(null);
		}
		public static Time GenerateDeathTime (Simulant simulant) {
			// time now + 0-111 years
			// normal distribution at 77
			return new Time(null);
		}
	}
}
