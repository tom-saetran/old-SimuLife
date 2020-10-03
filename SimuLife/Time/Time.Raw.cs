namespace SimuLife {
	partial class Time {
		public static uint Raw { get; protected set; }

		public static uint GetRawFromTime(Time time) {
			uint result	 =		   time.Year        * 336;
				 result += (uint) (time.Season + 1) * 84;
				 result += (uint) (time.Day    + 1) * 12;
				 result += (uint) (time.Hour   + 1);

			return result;
		}

		public static Time SetFromRawTime(uint rawTime) {
			return new Time((Hours)  (rawTime      % 12),
							(Days)   (rawTime / 12 %  7),
							(Seasons)(rawTime / 84 %  4),
							          rawTime / 336);
		}
	}
}
