using System;

namespace SimuLife {
	static class Generators {

		public static readonly Random Random = new Random();

		public static Simulant.Genders GenerateGender () {
			return Random.NextDouble() < 0.5 ?
				   Simulant.Genders.Female   :
			       Simulant.Genders.Male;
		}
		public static Name GenerateName (Simulant simulant) {
			return new Name("First", "Last");
		}
		public static TimeCard GenerateBirthTime (Simulant simulant) {
			// time now + ~3 Seasons
			// 18-24 days
			TimeCard time = new TimeCard(Simulator.TimeNow);
			return time; // TODO: FIX
		}
		public static TimeCard GenerateDeathTime (Simulant simulant) {
			// time now + 0-111 years
			// normal distribution at 77
			TimeCard time = new TimeCard(Simulator.TimeNow);
			return time;
		}
	}
}
