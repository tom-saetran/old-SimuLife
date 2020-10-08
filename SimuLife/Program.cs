using System;
using static SimuLife.Simulator;

namespace SimuLife {
	class Program {
		static void Main () {
			Population population = new Population(1000);
			WriteTime();
			Environment.Exit(420);
		}

		static void WriteTime () {
			Console.WriteLine(
				"Time is " + TimeNow.Hour   + 
					  ", " + TimeNow.Day    + 
					  ", " + TimeNow.Season + 
					  ", " + TimeNow.Year);
		}
	}
}
