namespace SimuLife {
	partial class Simulant {
		public enum HealthStages {
			Dead,
			Alive
		}

		public HealthStages HealthStage =>
			TimeOfDeath > Simulator.Time ? HealthStages.Alive : HealthStages.Dead;
	}
}
