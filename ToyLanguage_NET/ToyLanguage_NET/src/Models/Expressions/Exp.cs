using System;

namespace ToyLanguage_NET {
	public interface Exp {
		int eval (MapInterface<String, int> tbl);
	}
}

