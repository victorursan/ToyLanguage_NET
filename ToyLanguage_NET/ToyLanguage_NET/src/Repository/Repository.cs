using System;

namespace ToyLanguage_NET {
	public interface Repository {
		PrgState getCrtProgram ();

		void serializePrgStatet ();

		void logPrgState ();

		void deserializePrgStatet ();
	}
}

