using System;

namespace ToyLanguage_NET {
	public interface Exp {
		string ToString ();

		int eval (MapInterface<String, int> tbl, HeapInterface<int> heap);
	}
}

