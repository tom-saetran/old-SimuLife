namespace SimuLife {
	static partial class Simulator {
		public static TimeCard TimeNow	{ get; private set; }
		public static TimeCard TimeNext { get; private set; }
		
		static Simulator () {
			TimeNow  = new TimeCard(0,0,0,420);
			TimeNext = new TimeCard(0,0,0,420);
		}
	}
}
