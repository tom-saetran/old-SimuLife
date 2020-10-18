namespace SimuLife {
	partial class TimeCard {
		public uint Ticks => GetTicksFromTimeCard(this);

		public static uint GetTicksFromTimeCard (TimeCard time) {
			return (time.Year   * 336) +
			((uint) time.Season * 84) +
			((uint) time.Day    * 7) +
			 (uint) time.Hour;
		}

		public static TimeCard GetTimeCardFromTicks (uint rawTime) {
			return new TimeCard((Hours)  (rawTime      % 12),
								(Days)   (rawTime / 12 %  7),
								(Seasons)(rawTime / 84 %  4),
							   /*Years*/  rawTime / 336);
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
