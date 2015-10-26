using System;
using System.Collections;

namespace ToyLanguage_NET {
	public interface StackInterface: IEnumerable {
		int Count { get; }
		IStmt Pop();
		IStmt Peek();
		void Push (IStmt obj);
	}
}

