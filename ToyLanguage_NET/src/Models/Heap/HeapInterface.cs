using System;

namespace ToyLanguage_NET {
	public interface HeapInterface<T> {
		int Add(T e);
		T Get(int address);
		void Update (int address, T value);
	}
}

