using System;
using System.Collections.Generic;
using System.Text;

namespace SimuLife {
	class Schedule {
		/* follows time and fires events when the time is right
		 * 
		 * some constructed schedules cant be broken, like elementary school
		 * others can fluctuate, like sleep, or mundane tasks, by adding
		 * chance to its ecevution, if it misfires, reschedule with a new
		 * timecard with the same event at a random time calculated from
		 * how high importance the misfired task had.
		 * 
		 * it is more important to take care of dead grandma in the living
		 * room, than to vacuum the floor, but less important than to take
		 * care of the house that is on fire. 
		 * 
		 */
	}
}
