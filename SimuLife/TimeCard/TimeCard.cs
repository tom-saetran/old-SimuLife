using System;

namespace SimuLife {
	partial class TimeCard {
		public uint Ticks { get; }

		public Hours   Hour   => (Hours)  (Ticks % 12);
		public Days    Day    => (Days)   (Ticks / 12 % 7);
		public Seasons Season => (Seasons)(Ticks / 84 % 4);
		public uint    Year   =>           Ticks / 336;

		public const ushort TicksInYear = 336;
		public const ushort TicksInSeason = 84;

		public const ushort MaxHours   = 12;
		public const ushort MaxDays    =  7;
		public const ushort MaxSeasons =  4;

		public TimeCard (Hours hour, Days day, Seasons season, uint year) {
			Ticks = ((uint) hour   * MaxHours)   +
					((uint) day    * MaxDays)    +
					((uint) season * MaxSeasons) +
					        year   * TicksInYear;
		}

		public TimeCard (TimeCard time) {
			Ticks = ((uint) time.Hour   * MaxHours)   +
					((uint) time.Day    * MaxDays)    +
					((uint) time.Season * MaxSeasons) +
					        time.Year   * TicksInYear;
		}

		public static uint GetTicksFromTimeCard (TimeCard time) {
			return (time.Year   * 336) +
			((uint) time.Season * 84) +
			((uint) time.Day    * 7) +
			 (uint) time.Hour;
		}

		public static TimeCard GetTimeCardFromTicks (uint tickTime) {
			return new TimeCard((Hours)  (tickTime      % 12),
								(Days)   (tickTime / 12 %  7),
								(Seasons)(tickTime / 84 %  4),
							   /*Years*/  tickTime / 336);
		}
	}
}
