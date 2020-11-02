namespace SimuLife {
	partial class Simulant {
		public enum AlertnessStages {
			Comatose,	
			Stuporous,
			Obtuned,
			Somnolent,
			Delirious,
			Confused,
			Conscious,
			Metaconscious
		}
		public      AlertnessStages AlertnessStage => AlertnessLevel switch {
			ushort n when n > 120 => AlertnessStages.Metaconscious,
			ushort n when n > 100 => AlertnessStages.Conscious,
			ushort n when n > 80  => AlertnessStages.Confused,
			ushort n when n > 60  => AlertnessStages.Delirious,
			ushort n when n > 40  => AlertnessStages.Somnolent,
			ushort n when n > 20  => AlertnessStages.Obtuned,
			ushort n when n > 10  => AlertnessStages.Stuporous,
			_					  => AlertnessStages.Comatose
		};
	}
}
