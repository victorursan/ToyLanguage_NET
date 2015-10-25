using System;

namespace ToyLanguage_NET {
	public interface Exp {
		int eval (MapInterface tbl);

		String toStr ();
	}
}

