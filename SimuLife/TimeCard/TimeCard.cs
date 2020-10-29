using System;

namespace SimuLife {
	partial class TimeCard {
		public uint Ticks { get; }

		public static readonly ushort MaxHours      = 12;
		public static readonly ushort MaxDays       =  7;
		public static readonly ushort MaxSeasons    =  4;
		public static readonly ushort TicksInSeason = 84;
		public static readonly ushort TicksInYear   = 336;

		public Hours   Hour   => (Hours)  (Ticks % MaxHours);
		public Days    Day    => (Days)   (Ticks / MaxHours % MaxDays);
		public Seasons Season => (Seasons)(Ticks / TicksInSeason % MaxSeasons);
		public uint    Year   =>           Ticks / TicksInYear;




		public TimeCard (Hours hour, Days day, Seasons season, uint year) {
			Ticks = ((uint) hour   * MaxHours)   +
					((uint) day    * MaxDays)    +
					((uint) season * MaxSeasons) +
					        year   * TicksInYear;
		}

		public TimeCard (uint ticks) {
			Ticks = ticks;
		}

		public static uint GetTicksFromTimeCard (TimeCard time) {
			return (time.Year   * TicksInYear)   +
			((uint) time.Season * TicksInSeason) +
			((uint) time.Day    * MaxDays)       +
			 (uint) time.Hour;
		}

		public static TimeCard GetTimeCardFromTicks (uint tickTime) {
			return new TimeCard(tickTime);
		}
	}
}
