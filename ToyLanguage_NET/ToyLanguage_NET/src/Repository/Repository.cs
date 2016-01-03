using System;
using System.Collections.Generic;

namespace ToyLanguage_NET {
	public interface Repository {
		
		List<PrgState> PrgStates { get; set; }

		void serializePrgStatet ();

		void logPrgState ();

		void deserializePrgStatet ();

	}
}

