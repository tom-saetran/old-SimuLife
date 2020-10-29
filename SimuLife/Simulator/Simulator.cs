using System;

namespace SimuLife {
	static class Simulator {

		public static uint Time { get; private set; }
		public static TimeCard TimeNow => new TimeCard(Time);

		static Simulator () {
			Time = TimeCard.GetTicksFromTimeCard(new TimeCard(0,0,0,420));
		}

		public enum YearlyEvents {
			AdvanceTime,
			NewYear,
			Spring,
			MidSummer,
			Harvest,
			Christmas
		}
		public enum SeasonalEvents {
			Monday,
			Tuesday,
			Wednesday,
			Thursday,
			Friday,
			Saturday,
			Sunday
		}
		public enum DailyEvents {
			Night,   LateNight,   EarlyMorning,
			Morning, LateMorning, EarlyDay,
			Day,     LateDay,     EarlyEvening,
			Evening, LateEvening, EarlyNight
		}
		public static void StartEvent (YearlyEvents yearlyEvent) {
			switch (yearlyEvent) {
				case YearlyEvents.AdvanceTime:
					AdvanceTime();
					break;
				case YearlyEvents.NewYear:
					YearlyNewYear();
					break;
				case YearlyEvents.Spring:
					YearlySpring();
					break;
				case YearlyEvents.MidSummer:
					YearlyMidSummer();
					break;
				case YearlyEvents.Harvest:
					YearlyHarvest();
					break;
				case YearlyEvents.Christmas:
					YearlyChristmas();
					break;
			}
		}
		public static void StartEvent (SeasonalEvents seasonalEvent) {
			switch (seasonalEvent) {
				case SeasonalEvents.Monday:
					SeasonalMonday();
					break;
				case SeasonalEvents.Tuesday:
					SeasonalTuesday();
					break;
				case SeasonalEvents.Wednesday:
					SeasonalWednesday();
					break;
				case SeasonalEvents.Thursday:
					SeasonalThursday();
					break;
				case SeasonalEvents.Friday:
					SeasonalFriday();
					break;
				case SeasonalEvents.Saturday:
					SeasonalSaturday();
					break;
				case SeasonalEvents.Sunday:
					SeasonalSunday();
					break;
			}
		}
		public static void StartEvent (DailyEvents dailyEvent) {
			switch (dailyEvent) {
				case DailyEvents.Night:
					break;
				case DailyEvents.LateNight:
					break;
				case DailyEvents.EarlyMorning:
					break;
				case DailyEvents.Morning:
					break;
				case DailyEvents.LateMorning:
					break;
				case DailyEvents.EarlyDay:
					break;
				case DailyEvents.Day:
					break;
				case DailyEvents.LateDay:
					break;
				case DailyEvents.EarlyEvening:
					break;
				case DailyEvents.Evening:
					break;
				case DailyEvents.LateEvening:
					break;
				case DailyEvents.EarlyNight:
					break;
			}
		}


		static void AdvanceTime () {
			Time++;
			if (Time % TimeCard.TicksInYear == 0)
				StartEvent(YearlyEvents.NewYear);

			if ((Time + 36) % TimeCard.TicksInYear == 0)
				StartEvent(YearlyEvents.Christmas);

			if ((Time + 84) % TimeCard.TicksInYear == 0)
				StartEvent(YearlyEvents.Harvest);

			if ((Time + 168) % TimeCard.TicksInYear == 0)
				StartEvent(YearlyEvents.MidSummer);

			if ((Time + 252) % TimeCard.TicksInYear == 0)
				StartEvent(YearlyEvents.Spring);
		}

		static void YearlySpring () {
			
		}
		static void YearlyMidSummer () {
			
		}
		static void YearlyHarvest () {
			
		}
		static void YearlyChristmas () {
			
		}
		static void YearlyNewYear () {
			
		}

		static void SeasonalMonday () {
			
		}
		static void SeasonalTuesday () {
			
		}
		static void SeasonalWednesday () {
			
		}
		static void SeasonalThursday () {
			
		}
		static void SeasonalFriday () {
			
		}
		static void SeasonalSaturday () {
			
		}
		static void SeasonalSunday () {
			
		}
	}
}
