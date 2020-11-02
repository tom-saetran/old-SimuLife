namespace SimuLife {
	partial class Simulant {
		public enum AwakenessStages {
			DeepAsleep,
			Asleep,
			NearAsleep,
			Tired,
			Awake,
			FullyAwake
		}
		public      AwakenessStages AwakenessStage => AwakenessLevel switch {
			ushort n when n > 100 => AwakenessStages.FullyAwake,
			ushort n when n > 40  => AwakenessStages.Awake,
			ushort n when n > 30  => AwakenessStages.Tired,
			ushort n when n > 20  => AwakenessStages.NearAsleep,
			ushort n when n > 10  => AwakenessStages.Asleep,
			_                     => AwakenessStages.DeepAsleep
		};
	}
}
