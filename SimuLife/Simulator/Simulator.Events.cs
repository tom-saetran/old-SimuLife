namespace SimuLife {
	static partial class Simulator {
		public enum Events {
			AdvanceTime,
			NewYear,
			Spring,
			MidSummer,
			Harvest,
			Christmas
		}

		public static void StartEvent (Events choice) {
			switch (choice) {
				case Events.NewYear:

					break;
				case Events.Spring:

					break;
				case Events.MidSummer:

					break;
				case Events.Harvest:

					break;
				case Events.Christmas:

					break;
				case Events.AdvanceTime:
					AdvanceTime();
					break;
			}
		}

		static void AdvanceTime () {

			TimeNow = TimeNext;

			int  nextHour   = (int) TimeNext.Hour;
			int  nextDay    = (int) TimeNext.Day;
			int  nextSeason = (int) TimeNext.Season;
			uint nextYear   =       TimeNext.Year;

			nextHour++;
			if (nextHour == Time.NumHours) {
				nextHour = 0;
				nextDay++;
				if (nextDay == Time.NumDays) {
					nextDay = 0;
					nextSeason++;
					if (nextSeason == Time.NumSeasons) {
						nextSeason = 0;
						nextYear++;
					}
				}
			}

			TimeNext = new Time((Time.Hours)   nextHour,
								(Time.Days)    nextDay,
								(Time.Seasons) nextSeason,
											   nextYear);
		}
	}
}
