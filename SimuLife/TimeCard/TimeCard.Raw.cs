namespace SimuLife {
	partial class TimeCard {
		public static uint Raw { get; protected set; }

		public static uint GetRawFromTime (TimeCard time) {
			uint result	 =		   time.Year        * 336;
				 result += (uint) (time.Season + 1) * 84;
				 result += (uint) (time.Day    + 1) * 12;
				 result += (uint) (time.Hour   + 1);

			return result;
		}

		public static TimeCard SetFromRawTime (uint rawTime) {
			return new TimeCard((Hours)  (rawTime      % 12),
								(Days)   (rawTime / 12 %  7),
								(Seasons)(rawTime / 84 %  4),
									      rawTime / 336);
		}
	}
}
