namespace SimuLife {
	partial class TimeCard {
		public uint Ticks => GetTicksFromTimeCard(this);

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

		public static int GetDifferenceInTicks(TimeCard first, TimeCard second) {
			return (int) (GetTicksFromTimeCard(first) - GetTicksFromTimeCard(second));
		}

		public static TimeCard GetDifferenceInTimeCard(TimeCard first, TimeCard second) {
			int difference = GetDifferenceInTicks(first, second);
			if (difference < 0)
				difference = -difference;
			return GetTimeCardFromTicks((uint)difference);
		}
	}
}
