using System;
using System.Collections.Generic;
using System.Text;

namespace SimuLife {
	static class Simulator {

		public static Time TimeNow { get; private set; }
		public static Time TimeNext { get; private set; }
	}

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

	class Time {
		public enum Hours {
			Night,   LateNight,   EarlyMorning,
			Morning, LateMorning, EarlyDay,
			Day,     LateDay,     EarlyEvening,
			Evening, LateEvening, EarlyNight
		}
		public enum Days {
			Monday, Tuesday, Wednesday, Thursday, Friday,
			Saturday, Sunday
		}
		public enum Seasons {
			Winter, Spring,
			Summer, Autumn
		}

		public Hours Hour { get; protected set; }
		public Days Day { get; protected set; }
		public Seasons Season { get; protected set; }
		public uint Year { get; protected set; }

		public Time (Hours hour, Days day, Seasons season, uint year) {
			Hour = hour;
			Day = day;
			Season = season;
			Year = year;
		}
		public Time (Time time) {
			Hour = time.Hour;
			Day = time.Day;
			Season = time.Season;
			Year = time.Year;
		}
	}
}
