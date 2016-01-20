using System;

namespace ToyLanguage_NET {
	public interface IStmt {
		string ToString ();

		PrgState execute (PrgState state);
	}
}


