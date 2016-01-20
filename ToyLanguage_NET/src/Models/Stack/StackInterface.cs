using System;
using System.Collections;

namespace ToyLanguage_NET {
	  public interface StackInterface<T> {
		int Count { get; }
		T Pop();
		T Peek();
		void Push (T obj);
	}
}

