using System.Runtime.CompilerServices;

namespace SimuLife {
	partial class TimeCard {
		public uint Ticks => GetTicksFromTimeCard(this);

		public static uint GetTicksFromTimeCard (TimeCard time) {
			uint result	 =		   time.Year        * 336;
				 result += (uint) (time.Season + 1) * 84;
				 result += (uint) (time.Day    + 1) * 12;
				 result += (uint) (time.Hour   + 1);

			return result;
		}

		public static TimeCard SetTimeCardFromTicks (uint rawTime) {
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
			return SetTimeCardFromTicks((uint) GetDifferenceInTicks(first, second));
		}
	}
}
