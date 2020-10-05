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
			if (nextHour == TimeCard.NumHours) {
				nextHour = 0;
				nextDay++;
				if (nextDay == TimeCard.NumDays) {
					nextDay = 0;
					nextSeason++;
					if (nextSeason == TimeCard.NumSeasons) {
						nextSeason = 0;
						nextYear++;
					}
				}
			}

			TimeNext = new TimeCard((TimeCard.Hours)   nextHour,
								(TimeCard.Days)    nextDay,
								(TimeCard.Seasons) nextSeason,
											   nextYear);
		}
	}
}
