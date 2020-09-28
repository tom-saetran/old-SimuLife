using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SimuLife {
	class Program {
		static void Main(string[] args) {
			//Stopwatch stopwatch1 = new Stopwatch();
			//Stopwatch stopwatch2 = new Stopwatch();
			Stopwatch stopwatch3 = new Stopwatch();
			Simulant God = new Simulant(null, null);
			//Simulant[] arraySimulants = new Simulant[10000000];
			//List<Simulant> zeroListSimulants = new List<Simulant>(0);
			List<Simulant> preListSimulants = new List<Simulant>(10000000);

			/*stopwatch1.Start();
			for (int i = 0; i < 10000000; i++) {
				arraySimulants[i] = new Simulant(God, God);
				//listSimulants.Add(new Simulant(God, God));
			}
			stopwatch1.Stop();*/

			/*stopwatch2.Start();
			for (int i = 0; i < 10000000; i++) {
				//arraySimulants[i] = new Simulant(God, God);
				zeroListSimulants.Add(new Simulant(God, God));
			}
			stopwatch2.Stop();*/

			stopwatch3.Start();
			for (int i = 0; i < 10000000; i++) {
				//arraySimulants[i] = new Simulant(God, God);
				preListSimulants.Add(new Simulant(God, God));
			}
			stopwatch3.Stop();
			//Console.WriteLine("Took " + stopwatch1.ElapsedMilliseconds + "ms to create 1M Simulants with an array");
			//Console.WriteLine("Took " + stopwatch2.ElapsedMilliseconds + "ms to create 1M Simulants with a zero list");
			Console.WriteLine("Took " + stopwatch3.ElapsedMilliseconds + "ms to create 1M Simulants with a pre list");
			Console.ReadLine();
		}
	}
}
