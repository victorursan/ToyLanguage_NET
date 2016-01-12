using System;
using System.Collections;

namespace ToyLanguage_NET {
	public interface ListInterface<T> {
		void Add (T e);

		bool Contains (T e);

		int Count{ get; }

		T this [int index]{ get; set; }
	}

}

