namespace SimuLife {
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
