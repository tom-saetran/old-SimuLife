using System.Runtime.CompilerServices;

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
									      rawTime / 336);
		}

		public static int GetDifferenceInTicks(TimeCard first, TimeCard second) {
			int diff = (int) GetTicksFromTimeCard(first) - (int) GetTicksFromTimeCard(second);
			return diff;
		}

		public static TimeCard GetDifferenceInTimeCard(TimeCard first, TimeCard second) {
			return GetTimeCardFromTicks((uint) GetDifferenceInTicks(first, second));
		}
	}
}
