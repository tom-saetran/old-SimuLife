namespace SimuLife {
	static partial class Simulator {
		public static TimeCard TimeNow	{ get; private set; }
		public static TimeCard TimeNext { get; private set; }
		public static uint RawTime		{ get; private set; }
		
		static Simulator () {
			TimeNow  = new TimeCard(TimeCard.Hours.Night,     TimeCard.Days.Monday, TimeCard.Seasons.Winter, 420);
			TimeNext = new TimeCard(TimeCard.Hours.LateNight, TimeCard.Days.Monday, TimeCard.Seasons.Winter, 420);
			RawTime  =	   TimeCard.GetRawFromTime(TimeNow);
		}
	}
}
